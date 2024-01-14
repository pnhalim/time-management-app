using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class ActivityScene : MonoBehaviour
{
    public TextMeshProUGUI Title;
    public TextMeshProUGUI Time;
    public TextMeshProUGUI Reason;
    public TextMeshProUGUI Hint;
    public RectTransform Fill;

    public List<string> Cycle;
    int cycleIndex;

    public List<ActivityScriptableObject> ActivitiesDatabase;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("CurrentActivity"))
        {
            SceneManager.LoadScene("Home");
        }
        else
        {
            ActivityScriptableObject curr = FindActivity(PlayerPrefs.GetString("CurrentActivity"));

            if (curr == null)
            {
                PlayerPrefs.DeleteKey("CurrentActivity");
                SceneManager.LoadScene("Home");
            }

            InitActivity(curr);
        }
    }

    private ActivityScriptableObject FindActivity(string f_activityName)
    {
        foreach (ActivityScriptableObject activity in ActivitiesDatabase)
        {
            if (activity.Name == f_activityName)
            {
                return activity;
            }
        }

        // not found
        return null;
    }

    private void InitActivity(ActivityScriptableObject f_activity)
    {
        Cycle = new();
        cycleIndex = 0;

        Title.text = f_activity.Name;
        Cycle.Add("Title");

        if (f_activity.Reason.Trim() != "")
        {
            Reason.text = f_activity.Reason.Replace("- ", "\n").Trim();
            Cycle.Add("Reason");
        }
        if (f_activity.Hint.Trim() != "")
        {
            Hint.text = f_activity.Hint.Trim();
            Cycle.Add("Hint");
        }

        ActivityInstance Instance = gameObject.AddComponent<ActivityInstance>();
        Instance.Activity = f_activity;

        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        ActivityInstance Instance = GetComponent<ActivityInstance>();

        float totalHours = Instance.Activity.Hours;
        float prevHours = Instance.LoadHours();
        DateTime Start = Instance.LoadStart();

        while (true)
        {
            float hours = prevHours - ((float)(DateTime.Now - Start).TotalHours);

            UpdateTime(
                (int)(Math.Truncate(hours)),
                (int)(Math.Ceiling((hours - Math.Truncate(hours)) * 60f))
                );

            UpdateFill((totalHours - hours) / totalHours);

            yield return new WaitForSeconds(30f);
        }
    }

    private void UpdateFill(float percent)
    {
        // total fill is 970
        Fill.sizeDelta = new Vector2(Fill.sizeDelta.x, percent * 970);

    }

    private void UpdateTime(int f_hours, int f_minutes)
    {
        Time.text = "";

        if (Math.Abs(f_hours) >= 1)
        {
            Time.text = f_hours.ToString() + " hr ";
        }
        
        Time.text += f_minutes.ToString() + " m";
    }

    public void OnDoneButtonPressed()
    {
        GetComponent<ActivityInstance>().Save();
        PlayerPrefs.DeleteKey("CurrentActivity");
        SceneManager.LoadScene("Home");
    }

    public void OnCycleButtonPressed()
    {
        cycleIndex = (cycleIndex + 1) % Cycle.Count;
        string curr = Cycle[cycleIndex];

        Title.gameObject.SetActive(false);
        Reason.gameObject.SetActive(false);
        Hint.gameObject.SetActive(false);

        switch (curr)
        {
            case "Title":
                Title.gameObject.SetActive(true);
                break;
            case "Reason":
                Reason.gameObject.SetActive(true);
                break;
            case "Hint":
                Hint.gameObject.SetActive(true);
                break;
            default:
                Title.gameObject.SetActive(true);
                break;
        }


        Debug.Log(curr);
    }

}
