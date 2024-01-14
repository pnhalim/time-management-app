using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ActivityInstance : MonoBehaviour
{
    public ActivityScriptableObject Activity;
    float HoursRemaining;
    DateTime StartTime;

    public DateTime LoadStart()
    {
        if (PlayerPrefs.HasKey(Activity.Name + "_started"))
        {
            // load existing data
            StartTime = DateTime.Parse(PlayerPrefs.GetString(Activity.Name + "_started"));
        }
        else
        {
            // create blank key
            StartTime = DateTime.Now;
            PlayerPrefs.SetString(Activity.Name + "_started", StartTime.ToString());
        }

        return StartTime;
    }

    public float LoadHours()
    {
        if (PlayerPrefs.HasKey(Activity.Name + "_hours"))
        {
            // load existing data
            HoursRemaining = PlayerPrefs.GetFloat(Activity.Name + "_hours");
        }
        else
        {
            // create blank key
            PlayerPrefs.SetFloat(Activity.Name + "_hours", Activity.Hours);
            HoursRemaining = Activity.Hours;
        }

        return HoursRemaining;
    }

    public void Save()
    {
        Debug.Log("Saving");
        HoursRemaining = HoursRemaining - (float)(DateTime.Now - StartTime).TotalHours;
        PlayerPrefs.SetFloat(Activity.Name + "_hours", HoursRemaining);

        PlayerPrefs.DeleteKey(Activity.Name + "_started");
    }
}
