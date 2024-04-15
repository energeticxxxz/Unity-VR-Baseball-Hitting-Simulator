using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool rightHanded = false;

    public GameObject player;

    public GameObject rightHandedSpawn;

    public GameObject leftHandedSpawn;

    public GameObject rightBat;

    public GameObject leftBat;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnPlayer()
    {
        if (rightHanded)
        {
            player.transform.position = rightHandedSpawn.transform.position;
            leftBat.SetActive(true);
        }
        else
        {
            player.transform.position = leftHandedSpawn.transform.position;
            rightBat.SetActive(true);
        }


    }

}
