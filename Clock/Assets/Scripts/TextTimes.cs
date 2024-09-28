using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextTimes : MonoBehaviour
{
    [SerializeField] TMP_Text NY, LA, Dublin, Madrid;
    // Connected to text meshes
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        // Sets all local times in text
        NY.text = DateTime.Now + "";

        List<TimeZoneInfo.AdjustmentRule> adjustmentList = new List<TimeZoneInfo.AdjustmentRule>();
        adjustmentList.Add(TimeZoneInfo.AdjustmentRule.CreateAdjustmentRule(
                DateTime.MinValue.Date,
                DateTime.MaxValue.Date,
                new TimeSpan(1,0,0),
                TimeZoneInfo.TransitionTime.CreateFloatingDateRule(new DateTime(1, 1, 1, 2, 0, 0), 3, 2, DayOfWeek.Sunday),
                TimeZoneInfo.TransitionTime.CreateFloatingDateRule(new DateTime(1, 1, 1, 1, 0, 0), 11, 1, DayOfWeek.Sunday)
            ));
        LA.text = TimeZoneInfo.ConvertTime(DateTime.Now, 
        TimeZoneInfo.CreateCustomTimeZone("PT", new TimeSpan(-8, 0, 0), "PST", "PST", "PDT", adjustmentList.ToArray())) + "";

        adjustmentList = new List<TimeZoneInfo.AdjustmentRule>();
        adjustmentList.Add(TimeZoneInfo.AdjustmentRule.CreateAdjustmentRule(
                DateTime.MinValue.Date,
                DateTime.MaxValue.Date,
                new TimeSpan(1,0,0),
                TimeZoneInfo.TransitionTime.CreateFloatingDateRule(new DateTime(1, 1, 1, 2, 0, 0), 3, 5, DayOfWeek.Sunday),
                TimeZoneInfo.TransitionTime.CreateFloatingDateRule(new DateTime(1, 1, 1, 1, 0, 0), 10, 5, DayOfWeek.Sunday)
            ));
        Dublin.text = TimeZoneInfo.ConvertTime(DateTime.Now, 
        TimeZoneInfo.CreateCustomTimeZone("DT", new TimeSpan(0, 0, 0), "DST", "DST", "DDT", adjustmentList.ToArray())) + "";

        adjustmentList = new List<TimeZoneInfo.AdjustmentRule>();
        adjustmentList.Add(TimeZoneInfo.AdjustmentRule.CreateAdjustmentRule(
                DateTime.MinValue.Date,
                DateTime.MaxValue.Date,
                new TimeSpan(1,0,0),
                TimeZoneInfo.TransitionTime.CreateFloatingDateRule(new DateTime(1, 1, 1, 2, 0, 0), 3, 5, DayOfWeek.Sunday),
                TimeZoneInfo.TransitionTime.CreateFloatingDateRule(new DateTime(1, 1, 1, 1, 0, 0), 10, 5, DayOfWeek.Sunday)
            ));
        Madrid.text = TimeZoneInfo.ConvertTime(DateTime.Now, 
        TimeZoneInfo.CreateCustomTimeZone("MT", new TimeSpan(1, 0, 0), "MST", "MST", "MDT", adjustmentList.ToArray())) + "";
    }
}
