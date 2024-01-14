using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ActivityButton : MonoBehaviour
{
    public TextMeshProUGUI Title;
    public TextMeshProUGUI Time;
    public Image Capsule;

    public void InitButton(string f_activity, int f_minutes, int f_total)
    {
        Title.text = f_activity;
        Time.text = f_minutes.ToString() + " m";

        float percent_remaining = (float)f_minutes / (float)f_total;
        if (percent_remaining > 0.6f)
        {
            // green
            Capsule.color = new Color(0.3465053f, 0.754717f, 0.36773f);
        }
        else if (percent_remaining > 0.2f)
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
        Debug.Log("Button Pressed");
    }

}
