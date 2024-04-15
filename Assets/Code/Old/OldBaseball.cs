using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldBaseball : MonoBehaviour

{   
    public float lifespan = 5;
    public bool wasHit = false;
    
    public Rigidbody rb;
    public Vector3 force;
    // Start is called before the first frame update
    void Start()
    {
     rb.AddForce(force, ForceMode.Impulse);
    }

    void Despawn()
    {
        lifespan -= Time.deltaTime;
        if (lifespan <= 0 && wasHit == false) 
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        Despawn();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Baseball Bat")
        {
            wasHit = true;
        }
    }
}
