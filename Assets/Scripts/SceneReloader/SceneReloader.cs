using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReloader : MonoBehaviour
{
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

    private void OnPaused(float obj)
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
       

}


