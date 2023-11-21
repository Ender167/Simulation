using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Day_Night_Cycle : MonoBehaviour
{
    public Clock clock = new Clock();
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        clock.incrementSeconds(Time.deltaTime);
    }
}

[System.Serializable]
public class Clock
{
    [SerializeField]
    public double seconds;

    [SerializeField]
    public int minutes;

    [SerializeField]
    public int hours;

    [SerializeField]
    public int days;

    [SerializeField]
    public int months;

    [SerializeField]
    public int years;

    [SerializeField]
    public double seconds_in_minute = 60;

    [SerializeField]
    public int minutes_in_hour = 60;

    [SerializeField]
    public int hours_in_day = 24;

    [SerializeField]
    public int days_in_month = 30;

    [SerializeField]
    public int months_in_year = 12;

    public Clock()
    {
        seconds = 0;
        minutes = 0;
        hours = 0;
        days = 0;
        months = 0;
        years = 0;

        seconds_in_minute = 60;
        minutes_in_hour = 60;
        hours_in_day = 24;
        days_in_month = 30;
        months_in_year = 12;
    }

    public void incrementSeconds(double val)
    {
        seconds += val;
        if(seconds >= seconds_in_minute)
        {
            minutes++;
            if(minutes >= minutes_in_hour)
            {
                hours++;
                if(hours >= hours_in_day)
                {
                    days++;
                    if(days >= days_in_month)
                    {
                        months++;
                        if(months >= months_in_year)
                        {
                            years++;
                            months = 0;
                        }
                        days = 0;
                    }
                    hours = 0;
                }
                minutes = 0;
            }
            seconds = 0;
        }
    }
}
