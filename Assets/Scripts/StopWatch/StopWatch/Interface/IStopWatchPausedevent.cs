using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStopWatchPausedevent 
{
    public event Action<float> PausedEvent;

}
