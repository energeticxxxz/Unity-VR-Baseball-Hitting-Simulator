using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Game Scene");

    }

    public void ExitGame()
    {
        Debug.Log("Application has closed");
        Application.Quit(0);
    }
}