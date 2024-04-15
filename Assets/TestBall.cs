using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;
public class TestBall : Baseball
{
    void OnCollisionEnter(Collision collision)
    {
        GameObject marker = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        marker.AddComponent<KillScript>();
        marker.GetComponent<SphereCollider>().enabled = false;
        marker.transform.position = transform.position;
        marker.transform.localScale = transform.localScale * 10;
        marker.GetComponent<Renderer>().material.color = Color.red;
    }

}