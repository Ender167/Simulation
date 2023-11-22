using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Day_Night_Cycle : MonoBehaviour
{
    public Clock clock = new Clock();
    public List<hour_position> light_position = new List<hour_position>();
    public Light scene_light;

    public string current_day_state = "";

    int current_hour = -1;

    // Start is called before the first frame update
    void Start()
    {
        hour_position new_rot = FindLightPosition();
        scene_light.transform.rotation = Quaternion.Euler(new_rot.pos);
        current_hour = new_rot.hour;
        CheckForNewState();

    }

    // Update is called once per frame
    void Update()
    {
        float rotationX = (float) 360f / (float) (clock.hours_in_day * clock.minutes_in_hour * clock.seconds_in_minute);
        scene_light.transform.rotation *= Quaternion.Euler(Time.deltaTime * rotationX, 0f, 0f);
        clock.incrementSeconds(Time.deltaTime);
        CheckForNewHour();
    }

    hour_position FindLightPosition()
    {
        hour_position result = new hour_position();
        for (int i = 0; i < light_position.Count; i++)
        {
            if (light_position[i].hour == clock.hours)
            {
                result = light_position[i];
                break;
            }

        }
        return result;
    }
    void SetCurrentHour(int new_hour)
    {
        current_hour = new_hour;
    }
    public void CheckForNewHour()
    {
        if (current_hour != clock.hours)
        {
            SetCurrentHour(clock.hours);
            CheckForNewState();
        }
    }
    void CheckForNewState()
    {
        int i = 0;
        while(i < light_position.Count - 1)
        {
            if(current_hour >= light_position[i].hour && current_hour < light_position[i+1].hour)
            {
                current_day_state = light_position[i].state;
                break;
            }
            i++;
        }
    }
    
}

[System.Serializable]
public class hour_position
{
    public int hour;
    public Vector3 pos;
    public String state;
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
    public double timeToDegrees()
    {
        return 360/(seconds * minutes * hours);
    }
    public void incrementSeconds(double val)
    {
        seconds += val;

        while (seconds >= seconds_in_minute && seconds - seconds_in_minute >= 0)
        {
            seconds -= seconds_in_minute;

            minutes++;
        }
        while(minutes >= minutes_in_hour && minutes - minutes_in_hour >= 0)
        {
            minutes -= minutes_in_hour;

            hours++;
        }

        while(hours >= hours_in_day && hours - hours_in_day >= 0)
        {
            hours -= hours_in_day;

            days++;
        }

        while(days >= days_in_month && days - days_in_month >= 0)
        {
            days -= days_in_month;

            months++;
        }

        while (months >= months_in_year && months - months_in_year >= 0)
        {
            months -= months_in_year;

            years++;
        }
    }
}
