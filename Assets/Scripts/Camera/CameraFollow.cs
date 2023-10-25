using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _followTransform;
    [SerializeField] private Transform _lookAt;


        private void Update()
    {
        transform.position = _followTransform.position;
        transform.LookAt(_lookAt.position);
    }
}
