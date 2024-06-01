using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject player;

    public GameObject rightHandedSpawn;

    public GameObject leftHandedSpawn;

    public GameObject rightBat;

    public GameObject leftBat;

    // Start is called before the first frame update
    void Start()
    {
        SetPlayerPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPlayerPosition()
    {
        if (PlayerSettings.Instance.RightHanded)
        {
            player.transform.position = rightHandedSpawn.transform.position;

            //disable old bat and destroy capsules
            BatCapsuleFollower.DestroyBatCapsuleFollowers();

            rightBat.SetActive(false);

            //enable new bat (automatically creates new capsules
            leftBat.SetActive(true);

            Debug.Log("switching to right handed mode");

        }
        else
        {
            player.transform.position = leftHandedSpawn.transform.position;

            //disable old bat and destroy capsules
            BatCapsuleFollower.DestroyBatCapsuleFollowers();

            leftBat.SetActive(false);

            //enable new bat (automatically creates new capsules
            rightBat.SetActive(true);

            Debug.Log("switching to left handed mode");

        }
    }

}
