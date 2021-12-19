using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    private int number;
    
    public Button menu;

    public GameObject systemButtons;
    public GameObject SettingsCanvas;

    public void ActivateButtons()
    {
       systemButtons.SetActive(true);
    }

    public void TurnOffButtons()
    {
       systemButtons.SetActive(false);
    }

    public void Home(int index)
    {
        SceneManager.LoadScene(4);
    }

    public void Skins(int index)
    {
        SceneManager.LoadScene(0);
    }

    public void Settings()
    {
        SettingsCanvas.SetActive(true);
    }
}
