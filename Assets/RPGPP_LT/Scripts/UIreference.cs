using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class UIreference : MonoBehaviour
{
    public Text notification;
    public Text timer;
    public Text fishCount;
    private float lastNotfication;
    private bool notificationActive;
    public float timeoffset;
    public int fishAmount = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TimeSpan span = TimeSpan.FromSeconds(Time.time + timeoffset);
        timer.text = $"Time played: {span.Hours.ToString("00")}:{span.Minutes.ToString("00")}:{span.Seconds.ToString("00")}";
        if (notificationActive) 
        {
            if(Time.time >= lastNotfication + 1)
            {
                notification.text = "";
                notificationActive = false;
            }
        }
    }

    public void UpdateFishCount()
    {
        fishCount.text = "Fish: " + fishAmount;
    }

    public void catchFish() 
    {
        notification.text = "You caught a fish";
        notificationActive = true;
        lastNotfication = Time.time;
        fishAmount += 1;
        UpdateFishCount();
    }
}
