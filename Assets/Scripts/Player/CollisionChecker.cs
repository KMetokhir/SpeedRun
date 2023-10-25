using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionChecker : MonoBehaviour
{
    public event Action StartButtunPressedEvent;
    public event Action StopButtonPressedEvent;

    private  void OnCollisionEnter(Collision collision)
    {         
        if (collision.gameObject.TryGetComponent<StartButton>(out var startButton))
        {
            if (startButton.IsPressed)
            {
                return;
            }
            else {
                startButton.Press();
                StartButtunPressedEvent?.Invoke();                
            }
            
        }

        if (collision.gameObject.TryGetComponent<StopButton>(out var stopButton))
        {
            if (stopButton.IsPressed)
            {
                return;
            }
            else
            {
                stopButton.Press();
                StopButtonPressedEvent?.Invoke();
            }
        }


    }
}
