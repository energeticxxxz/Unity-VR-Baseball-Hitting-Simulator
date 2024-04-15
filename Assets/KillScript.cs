using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillScript : MonoBehaviour
{

    public float lifespan = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lifespan <= 0)
            Destroy(gameObject);

        lifespan -= Time.deltaTime;
    }
}
