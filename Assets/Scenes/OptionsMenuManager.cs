using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenuManager : MonoBehaviour
{

    public void ReturntoMenu()
    {
        SceneManager.LoadScene(0);
    }

}
