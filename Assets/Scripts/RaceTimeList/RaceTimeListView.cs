using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RaceTimeListView : MonoBehaviour
{
    private TMP_Text _timeText;

    private void Awake()
    {
        _timeText = GetComponent<TMP_Text>();

    }

    public void SetValue(string textList)
    {
        _timeText.text = textList; 
    }
}
