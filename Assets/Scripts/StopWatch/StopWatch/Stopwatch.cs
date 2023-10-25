using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stopwatch : MonoBehaviour, IStopWatchPausedevent
{
    public event Action<float> PausedEvent;    

    [SerializeField] private StopwatchType _stopWatchType;
    [SerializeField] private StopwatchView _view;
    private StopwatchModel _model;

    private void Awake()
    {
        _model = new StopwatchModel(_stopWatchType);       
    }

    private void OnEnable()
    {
        _model.TimeValueChangedEvent += OnTimeValueChanged;        
    }

    private void OnDisable()
    {
        _model.TimeValueChangedEvent -= OnTimeValueChanged;
    }


    private void OnTimeValueChanged(float time)
    {       
        _view.SetValue(time);        
    }

    public void StartTime()
    {
        _model.Start();
    }

    public void Pause()
    {
        _model.Pause();
       
        PausedEvent?.Invoke(_model.Seconds);        
    }
}
