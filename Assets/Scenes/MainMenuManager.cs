using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;


public class MainMenuManager : MonoBehaviour
{
    public TMP_Text LeftyRightyText;
    public Image TracePitchCheckmark;
    public Image TraceHitCheckmark;



    private void Start()
    {
        InitializeMenu();
    }

    public void InitializeMenu()
    {
        //lefty righty setup
        if (PlayerSettings.Instance.RightHanded == false)
            LeftyRightyText.text = "Lefty";
        else
            LeftyRightyText.text = "Righty";

        //trace checkmark
        if (PlayerSettings.Instance.TracePitch == false)
            TracePitchCheckmark.gameObject.SetActive(false);
        else
            TracePitchCheckmark.gameObject.SetActive(true);

        //hit checkmark
        if (PlayerSettings.Instance.TraceHit == false)
            TraceHitCheckmark.gameObject.SetActive(false);
        else
            TraceHitCheckmark.gameObject.SetActive(true);

    }



    /*
     * UI Button Functions vv
     */

    public void StartGame()
    {
        SceneManager.LoadScene("Game Scene");

    }

    public void ExitGame()
    {
        Debug.Log("Application has closed");
        Application.Quit(0);
    }

    public void LeftyRightySetting()
    {
        if (PlayerSettings.Instance.RightHanded == false)
        {
            PlayerSettings.Instance.RightHanded = true;
            LeftyRightyText.text = "Righty";
        }
        else
        {
            PlayerSettings.Instance.RightHanded = false;
            LeftyRightyText.text = "Lefty";
        }
    }

    public void TracePitchSetting()
    {
        if (PlayerSettings.Instance.TracePitch == false)
        {
            PlayerSettings.Instance.TracePitch= true;
            TracePitchCheckmark.gameObject.SetActive(true);
        }
        else
        {
            PlayerSettings.Instance.TracePitch = false;
            TracePitchCheckmark.gameObject.SetActive(false);
        }
    }

    public void TraceHitSetting()
    {
        if (PlayerSettings.Instance.TraceHit == false)
        {
            PlayerSettings.Instance.TraceHit = true;
            TraceHitCheckmark.gameObject.SetActive(true);
        }
        else
        {
            PlayerSettings.Instance.TraceHit = false;
            TraceHitCheckmark.gameObject.SetActive(false);
        }
    }
}