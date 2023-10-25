using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IControllable 
{
    public void Move(Vector3 direction);

    public void Jump();

    public void LookAt(float inputX);
}
