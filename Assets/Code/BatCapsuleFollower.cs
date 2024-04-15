using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatCapsuleFollower : MonoBehaviour
{
    private BatCapsule _batFollower;
    private Rigidbody _rigidbody;
    private Vector3 _velocity;

    [SerializeField]
    private float _sensitivity = 100f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }


    //move velocity and position update logic to Update instead of FixedUpdate and test it out

    private void Update()
    {
        //update the position
        Vector3 destination = _batFollower.transform.position;
        _rigidbody.transform.rotation = transform.rotation;

        //recalculate velocity
        _velocity = (destination - _rigidbody.transform.position) * _sensitivity;

        //apply velocity
        _rigidbody.velocity = _velocity;

        //update physical position
        transform.position = destination;
        transform.rotation = _batFollower.transform.rotation;
    }
    
    public void SetFollowTarget (BatCapsule batFollower)
    {
        _batFollower = batFollower;
    }
}
