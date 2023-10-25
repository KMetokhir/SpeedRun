using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StopwatchView : MonoBehaviour
{
    private TMP_Text _timeText;

    private void Awake()
    {
        _timeText = GetComponent<TMP_Text>();

    }

    public void SetValue(float value)
    {
        _timeText.text = value.ToString("0.00") + "sec";        
    }
}
