using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{ 

    public bool IsGrounded { get; private set; }
   
    private PhysicalBody _body;

    private float _sphereRadius;
    private float _yOffset = 0.01f;  

    private LayerMask _groundLayerMask;


    private void Awake()
    {
        _body = GetComponentInChildren<PhysicalBody>();

        _groundLayerMask = LayerMask.GetMask("Ground");      

        _sphereRadius = _body.GetComponent<CapsuleCollider>().radius;
    }

    private void Update()
    {      
        var position = new Vector3(_body.transform.position.x, 
            _body.transform.position.y - _body.transform.localScale.y + _sphereRadius - _yOffset, 
            _body.transform.position.z );

        IsGrounded = Physics.CheckSphere(position, _sphereRadius, _groundLayerMask);       
    }

    /*void OnDrawGizmosSelected()
    {
        var position = new Vector3(_body.transform.position.x,
            _body.transform.position.y - _body.transform.localScale.y + _sphereRadius - _yOffset,
            _body.transform.position.z);

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(position, _sphereRadius);
    }*/
}
