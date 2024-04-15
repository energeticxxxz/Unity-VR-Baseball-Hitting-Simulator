using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseballBatController : MonoBehaviour
{
    public GameObject baseballBat;
    public float followSpeed = 10f;
    public Rigidbody rb;
    public bool isSwinging = false;
    public float swingTime = 0.5f;
    public float swingTimer = 0f;

    // list of baseball bat positions

    public Transform restPositionTransform;
    public Transform swingPositionTransform;
    public Transform swungPositionTransform;

    // active baseball bat position

    private Transform targetTransform;

    // Start is called before the first frame update
    void Start()
    {
        rb = baseballBat.GetComponent<Rigidbody>();
        targetTransform = restPositionTransform;
    }

    // Update is called once per frame
    void Update()
    {
        RaiseBat();
        SwingBat();
        FollowTarget();
        SwingTimer();
    }
    void FollowTarget()
    {
        rb.position = Vector3.Lerp(rb.position, targetTransform.position, followSpeed * Time.deltaTime);
        rb.rotation = Quaternion.Slerp(rb.rotation, targetTransform.rotation, followSpeed * Time.deltaTime);
        Debug.Log("Velocity: " + rb.velocity);
    }
    void RaiseBat()
    {
        if (Input.GetKey(KeyCode.Space) && isSwinging == false) 
        {
            targetTransform = swingPositionTransform;
        }
        else if(isSwinging == false)
        {
            targetTransform = restPositionTransform;
        }
    }
    void SwingBat()
    {
         if (Input.GetKey(KeyCode.Space))
         {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                targetTransform = swungPositionTransform;
                isSwinging = true;
                swingTimer = swingTime;
            }
         }
    }
    void SwingTimer()
    {
        if (isSwinging == true)
        {
            swingTimer -= Time.deltaTime;
        }
        if (swingTimer <= 0)
        {
            isSwinging = false;
        }
    }
}
