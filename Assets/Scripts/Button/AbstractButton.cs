using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractButton : MonoBehaviour
{
    public bool IsPressed { get; private set; }

    private Vector3 _pressedPosition;

    private void Awake()
    {
        _pressedPosition = new Vector3(transform.position.x, transform.position.y - transform.localScale.y, transform.position.z);
    }

    public void Press()
    {
        if (IsPressed)
        {
            return;
        }
        else
        {
            IsPressed = true;
        }
    }

    private void Update()
    {
        if (IsPressed)
        {
            var position = Vector3.Lerp(transform.position, _pressedPosition, Time.deltaTime);
            transform.position = position;
        }
    }
}
