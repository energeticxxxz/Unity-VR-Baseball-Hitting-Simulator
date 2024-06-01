using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BatCapsule : MonoBehaviour
{

    [SerializeField]
    private BatCapsuleFollower _batCapsuleFollowerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }

    private void OnEnable()
    {
        SpawnBatCapsuleFollower();
    }

    private void SpawnBatCapsuleFollower()
    {
        var follower = Instantiate(_batCapsuleFollowerPrefab);
        follower.transform.position = transform.position;

        Vector3 worldScale = transform.localScale;
        worldScale = Vector3.Scale(worldScale, transform.parent.localScale); //model scale
        worldScale = Vector3.Scale(worldScale, transform.parent.parent.localScale); //baseball bat scale
        worldScale = Vector3.Scale(worldScale, transform.parent.parent.parent.localScale); //left controller scale
        worldScale = Vector3.Scale(worldScale, transform.parent.parent.parent.parent.localScale); //camera offset scale
        worldScale = Vector3.Scale(worldScale, transform.parent.parent.parent.parent.parent.localScale); //XR Origin scale
        worldScale = Vector3.Scale(worldScale, transform.parent.parent.parent.parent.parent.parent.localScale); //player scale

        follower.transform.localScale = worldScale;


        follower.SetFollowTarget(this);

        BatCapsuleFollower.batCapsuleFollowers.Add(follower);
    }

}
