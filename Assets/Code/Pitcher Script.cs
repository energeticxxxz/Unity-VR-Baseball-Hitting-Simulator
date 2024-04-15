using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class PitcherScript : MonoBehaviour

{   
    // Countdown Variables
    [Header ("Baseball Spawn Variables")]
    public GameObject baseballPrefab;
    public Transform baseballSpawn;

    [Header("Pitch Profile Override")]
    public bool profileOverride = false;
    public int profileSelection = 0;

    [Header ("Baseball Pitch Presets")]
    public List<PitchData> pitchProfiles;

    [Header ("Countdown Variables")]
    public float countdown = 0;
    public float minimumTime = 9;
    public float maximumTime = 12;

    // Animation Variables
    [Header ("Animation Variables")]
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        countdown = UnityEngine.Random.Range(minimumTime/3, maximumTime/3);
    }

    // Update is called once per frame
    void Update()
    {   
        UpdateCountdownTimer();
        UpdatePitch();
    }
    void UpdateCountdownTimer()
    {
         if (countdown > 0)
        {
            countdown = countdown - Time.deltaTime;
        }
    }

    void UpdatePitch()
    {
        if (countdown < 0)
        {
            animator.SetTrigger("Start Pitch");
            countdown = UnityEngine.Random.Range(minimumTime, maximumTime);
        }
    }

    public void SpawnBaseball()
    {

        //Create new baseball and access it's Baseball script
        GameObject newBaseball = Instantiate(baseballPrefab, baseballSpawn.position, UnityEngine.Quaternion.identity);
        Baseball baseballScript = newBaseball.GetComponent <Baseball>();

        if (baseballScript == null)
            baseballScript = newBaseball.GetComponent<TestBall>();

        int profileNumber = UnityEngine.Random.Range(0, pitchProfiles.Count);

        if (!profileOverride)
        {
            baseballScript.InitializePitchData(pitchProfiles[profileNumber]);
            Debug.Log("Pitch Profile " + pitchProfiles[profileNumber].name + " activated");
        }
        else
        {
            baseballScript.InitializePitchData(pitchProfiles[profileSelection]);
            Debug.Log("Pitch Profile " + pitchProfiles[profileSelection].name + " activated");
        }

    }
}

