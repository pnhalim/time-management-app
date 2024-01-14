using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class ActivityButton : MonoBehaviour
{
    public TextMeshProUGUI Title;
    public TextMeshProUGUI Time;
    public Image Capsule;

    public void InitButton(string f_activity, int f_hours, int f_minutes, float f_percent_remaining)
    {
        // title
        Title.text = f_activity;

        // time
        Time.text = "";
        if (Math.Abs(f_hours) >= 1)
        {
            Time.text = f_hours.ToString() + " hr ";
        }
        Time.text += f_minutes.ToString() + " m";

        // background color
        if (f_percent_remaining > 0.6f)
        {
            // green
            Capsule.color = new Color(0.3465053f, 0.754717f, 0.36773f);
        }
        else if (f_percent_remaining > 0.2f)
        {
            // yellow
            Capsule.color = new Color(0.937255f, 0.8078432f, 0.2980392f);
        }
        else
        {
            // red
            Capsule.color = new Color(0.9607844f, 0.4705883f, 0.4705883f);
        }
    }

    public void OnButtonPressed()
    {
        PlayerPrefs.SetString("CurrentActivity", Title.text);
        SceneManager.LoadScene("Activity");
    }

}
