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
        // assume that no activity is in progress rn

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

        int minutes = ((int)Math.Ceiling(f_instance.LoadHours() * 60));
        int total = ((int)Math.Ceiling(f_instance.Activity.Hours * 60));

        button.InitButton(f_instance.Activity.Name, minutes, total);
    }
}
