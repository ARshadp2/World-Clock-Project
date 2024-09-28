using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldClock : MonoBehaviour
{
    public GameObject clock; // prefab
    private GameObject NewYork1, NewYork2, NewYork3, NewYork4, LosAngeles1, LosAngeles2,
    Dublin1, Dublin2, Madrid1, Madrid2, Madrid3, Madrid4; // all clocks
    // Start is called before the first frame update
    void Start()
    {
        //New York Clocks
        NewYork1 = Instantiate(clock, new Vector3(-30, 30, -12.5f), Quaternion.identity);
        NewYork2 = Instantiate(clock, new Vector3(-17.5f, 30, 0), Quaternion.Euler(0,-90,0));
        NewYork3 = Instantiate(clock, new Vector3(-30, 30, 12.5f), Quaternion.Euler(0,-180,0));
        NewYork4 = Instantiate(clock, new Vector3(-42.5f, 30, 0), Quaternion.Euler(0,90,0));
        //Los Angeles Clock
        LosAngeles1 = Instantiate(clock, new Vector3(0, 30, -3), Quaternion.identity);
        LosAngeles2 = Instantiate(clock, new Vector3(0, 30, 3), Quaternion.Euler(0,-180,0));
        //Dublin Clocks
        Dublin1 = Instantiate(clock, new Vector3(30, 30, -7.9f), Quaternion.identity);
        Dublin2 = Instantiate(clock, new Vector3(30, 30, 7.9f), Quaternion.Euler(0,-180,0));
        //Madrid Clocks
        Madrid1 = Instantiate(clock, new Vector3(65, 30, -11), Quaternion.identity);
        Madrid2 = Instantiate(clock, new Vector3(75, 30, 0), Quaternion.Euler(0,-90,0));
        Madrid3 = Instantiate(clock, new Vector3(65, 30, 11), Quaternion.Euler(0,-180,0));
        Madrid4 = Instantiate(clock, new Vector3(55, 30, 0), Quaternion.Euler(0,90,0));

        //Names in editor
        NewYork1.name = "New York 1";
        NewYork2.name = "New York 2";
        NewYork3.name = "New York 3";
        NewYork4.name = "New York 4";
        LosAngeles1.name = "Los Angeles 1";
        LosAngeles2.name = "Los Angeles 2";
        Dublin1.name = "Dublin 1";
        Dublin2.name = "Dublin 2";
        Madrid1.name = "London 1";
        Madrid2.name = "London 2";
        Madrid3.name = "London 3";
        Madrid4.name = "London 4";
    }

    // Update is called once per frame
    void Update()
    {
        //NY time
        NewYork1.GetComponent<Clock>().time = DateTime.Now.TimeOfDay;
        NewYork2.GetComponent<Clock>().time = DateTime.Now.TimeOfDay;
        NewYork3.GetComponent<Clock>().time = DateTime.Now.TimeOfDay;
        NewYork4.GetComponent<Clock>().time = DateTime.Now.TimeOfDay;
        //LA time
        List<TimeZoneInfo.AdjustmentRule> adjustmentList = new List<TimeZoneInfo.AdjustmentRule>();
        adjustmentList.Add(TimeZoneInfo.AdjustmentRule.CreateAdjustmentRule(
                DateTime.MinValue.Date,
                DateTime.MaxValue.Date,
                new TimeSpan(1,0,0),
                TimeZoneInfo.TransitionTime.CreateFloatingDateRule(new DateTime(1, 1, 1, 2, 0, 0), 3, 2, DayOfWeek.Sunday),
                TimeZoneInfo.TransitionTime.CreateFloatingDateRule(new DateTime(1, 1, 1, 1, 0, 0), 11, 1, DayOfWeek.Sunday)
            ));
        LosAngeles1.GetComponent<Clock>().time = TimeZoneInfo.ConvertTime(DateTime.Now, 
        TimeZoneInfo.CreateCustomTimeZone("PT", new TimeSpan(-8, 0, 0), "PST", "PST", "PDT", adjustmentList.ToArray())).TimeOfDay;
        LosAngeles2.GetComponent<Clock>().time = TimeZoneInfo.ConvertTime(DateTime.Now, 
        TimeZoneInfo.CreateCustomTimeZone("PT", new TimeSpan(-8, 0, 0), "PST", "PST", "PDT", adjustmentList.ToArray())).TimeOfDay;

        //Dublin time
        adjustmentList = new List<TimeZoneInfo.AdjustmentRule>();
        adjustmentList.Add(TimeZoneInfo.AdjustmentRule.CreateAdjustmentRule(
                DateTime.MinValue.Date,
                DateTime.MaxValue.Date,
                new TimeSpan(1,0,0),
                TimeZoneInfo.TransitionTime.CreateFloatingDateRule(new DateTime(1, 1, 1, 2, 0, 0), 3, 5, DayOfWeek.Sunday),
                TimeZoneInfo.TransitionTime.CreateFloatingDateRule(new DateTime(1, 1, 1, 1, 0, 0), 10, 5, DayOfWeek.Sunday)
            ));
        Dublin1.GetComponent<Clock>().time = TimeZoneInfo.ConvertTime(DateTime.Now, 
        TimeZoneInfo.CreateCustomTimeZone("DT", new TimeSpan(0, 0, 0), "DST", "DST", "DDT", adjustmentList.ToArray())).TimeOfDay;
        Dublin2.GetComponent<Clock>().time = TimeZoneInfo.ConvertTime(DateTime.Now, 
        TimeZoneInfo.CreateCustomTimeZone("DT", new TimeSpan(0, 0, 0), "DST", "DST", "DDT", adjustmentList.ToArray())).TimeOfDay;

        //Madrid time
        adjustmentList = new List<TimeZoneInfo.AdjustmentRule>();
        adjustmentList.Add(TimeZoneInfo.AdjustmentRule.CreateAdjustmentRule(
                DateTime.MinValue.Date,
                DateTime.MaxValue.Date,
                new TimeSpan(1,0,0),
                TimeZoneInfo.TransitionTime.CreateFloatingDateRule(new DateTime(1, 1, 1, 2, 0, 0), 3, 5, DayOfWeek.Sunday),
                TimeZoneInfo.TransitionTime.CreateFloatingDateRule(new DateTime(1, 1, 1, 1, 0, 0), 10, 5, DayOfWeek.Sunday)
            ));
        Madrid1.GetComponent<Clock>().time = TimeZoneInfo.ConvertTime(DateTime.Now, 
        TimeZoneInfo.CreateCustomTimeZone("MT", new TimeSpan(1, 0, 0), "MST", "MST", "MDT", adjustmentList.ToArray())).TimeOfDay;
        Madrid2.GetComponent<Clock>().time = TimeZoneInfo.ConvertTime(DateTime.Now, 
        TimeZoneInfo.CreateCustomTimeZone("MT", new TimeSpan(1, 0, 0), "MST", "MST", "MDT", adjustmentList.ToArray())).TimeOfDay;
        Madrid3.GetComponent<Clock>().time = TimeZoneInfo.ConvertTime(DateTime.Now, 
        TimeZoneInfo.CreateCustomTimeZone("MT", new TimeSpan(1, 0, 0), "MST", "MST", "MDT", adjustmentList.ToArray())).TimeOfDay;
        Madrid4.GetComponent<Clock>().time = TimeZoneInfo.ConvertTime(DateTime.Now, 
        TimeZoneInfo.CreateCustomTimeZone("MT", new TimeSpan(1, 0, 0), "MST", "MST", "MDT", adjustmentList.ToArray())).TimeOfDay;

        // NOTE: I created my own timezones because webgl cannot find the timezone ids. I took inspiration from Microsoft's official sample code on how to create these timezones.
    }
}
