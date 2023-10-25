using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RacesData 
{
   public static readonly List<float> RunsDataList = new List<float>();

   public static void AddRun(float timeValue)
    {
        if (timeValue <= 0)
        {
            //Debug.LogError($"Time of Run <= 0 {timeValue}");
            return;
        }

        RunsDataList.Add(timeValue);          
    }

    public static void PrintData()
    {
        foreach (var data in RunsDataList)
        {
            Debug.Log(data);
        }
    }
}
