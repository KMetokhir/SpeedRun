using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopwatchModel 
{
    public event Action<float> TimeValueChangedEvent;

    public StopwatchType type { get; }
    public float Seconds { get; private set; }
    public bool IsPaused { get; private set; }


    public StopwatchModel(StopwatchType type)
    {
        this.type = type;
        Seconds = 0f;
    }      

    public void Start()
    {       
        IsPaused = false;
        Subscribe();
        TimeValueChangedEvent?.Invoke(Seconds);
    }
   

    public void Pause()
    {
        IsPaused = true;
        UnSubscribe();
        TimeValueChangedEvent?.Invoke(Seconds);
    }

    public void Unpause()
    {
        IsPaused = false;
        Subscribe();
        TimeValueChangedEvent?.Invoke(Seconds);
    }

    public void Stop()
    {
        UnSubscribe();
        Seconds = 0;

        TimeValueChangedEvent?.Invoke(Seconds);      
    }

    private void Subscribe()
    {
        
        switch (type)
        {
            case StopwatchType.UpdateTick:
                TimeInvoker.Instance.UpdateTimeTickedEvent += OnUpdateTick;                
                break;
            case StopwatchType.UpdateTickUnscaled:
                TimeInvoker.Instance.UpdateTimeUnscaledTickedEvent += OnUpdateTick;
                break;
            case StopwatchType.OneSecTick:
                TimeInvoker.Instance.OneSecondTickedEvent += OnOneSecondtick;
                break;
            case StopwatchType.OneSecTickUnscaled:
                TimeInvoker.Instance.OneSecondUnscaledTickedEvent += OnOneSecondtick;
                break;
            default:
                break;
        }


    }

    private void UnSubscribe()
    {

        switch (type)
        {
            case StopwatchType.UpdateTick:
                TimeInvoker.Instance.UpdateTimeTickedEvent -= OnUpdateTick;
                break;
            case StopwatchType.UpdateTickUnscaled:
                TimeInvoker.Instance.UpdateTimeUnscaledTickedEvent -= OnUpdateTick;
                break;
            case StopwatchType.OneSecTick:
                TimeInvoker.Instance.OneSecondTickedEvent -= OnOneSecondtick;
                break;
            case StopwatchType.OneSecTickUnscaled:
                TimeInvoker.Instance.OneSecondUnscaledTickedEvent -= OnOneSecondtick;
                break;
            default:
                break;
        }
    }

    private void OnOneSecondtick()
    {
        if (IsPaused)
            return;

        Seconds += 1f;
        TimeValueChangedEvent?.Invoke(Seconds);
    }

    private void OnUpdateTick(float deltaTime)
    {
        if (IsPaused)
            return;

        Seconds += deltaTime;
        TimeValueChangedEvent?.Invoke(Seconds);
    }
   
}
