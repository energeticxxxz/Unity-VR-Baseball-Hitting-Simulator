using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public List<Transform> transforms;

    public int currentIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = transforms[currentIndex].position;
        transform.rotation = transforms[currentIndex].rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            //increase index
            currentIndex++;

            //check if it was too far
            if (currentIndex > transforms.Count - 1)
            {
                //if it was too far, go to zero
                currentIndex = 0;
            }

            //finally, apply it
            transform.position = transforms[currentIndex].position;
            transform.rotation = transforms[currentIndex].rotation;

        }
    }
}
