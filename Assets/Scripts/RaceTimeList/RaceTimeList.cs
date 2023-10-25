using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceTimeList : MonoBehaviour
{    
    [SerializeField] private RaceTimeListView _view;
    private IStopWatchPausedevent _pausedEvent;

    private void Awake()
    {
        _pausedEvent = FindObjectOfType<Stopwatch>();       
    }

    private void OnEnable()
    {
        _pausedEvent.PausedEvent += OnPaused;
    }    

    private void OnDisable()
    {
        _pausedEvent.PausedEvent -= OnPaused;
    }

    private void Start()
    {
        var viewTextValue = ConverListToString(RacesData.RunsDataList);

        _view.SetValue(viewTextValue);
    }

    private void OnPaused(float timeValue)
    {
        RacesData.AddRun(timeValue);
        var runsList = RacesData.RunsDataList;

        var viewTextValue = ConverListToString(runsList);

        _view.SetValue(viewTextValue);

    }
   

    private string ConverListToString(List<float> list)
    {
        string runsListText = "";

        for (int i = 0; i < list.Count; i++)
        {
            runsListText += "\n" + $" {i + 1}.  " + list[i].ToString("0.00") + " sec";

            Debug.Log($" {i + 1}  { runsListText}");
        }

        return runsListText;

    }
}
