using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ActivityButtons : MonoBehaviour
{
    public ActivityScriptableObject Activity1;
    public ActivityScriptableObject Activity2;

    public GameObject Button1;
    public GameObject Button2;

    ActivityInstance Instance1;
    ActivityInstance Instance2;

    private void Start()
    {
        // load button 1 data
        Instance1 = Button1.AddComponent<ActivityInstance>();
        Instance1.Activity = Activity1;
        SetButton(Button1, Instance1);
        

        // load button 2 data
        if (Activity2 == null)
        {
            Button2.SetActive(false);
        }
        else
        {
            Instance2 = Button2.AddComponent<ActivityInstance>();
            Instance2.Activity = Activity2;
            SetButton(Button2, Instance2);
        }
    }

    private void SetButton(GameObject f_button, ActivityInstance f_instance)
    {
        ActivityButton button = f_button.GetComponent<ActivityButton>();

        float time = f_instance.LoadHours();

        int hours = (int)Math.Truncate(time);
        int minutes = (int)Math.Ceiling((time - Math.Truncate(time)) * 60f);

        float percent_remaining = time / f_instance.Activity.Hours;

        button.InitButton(f_instance.Activity.Name, hours, minutes, percent_remaining);
    }
}
