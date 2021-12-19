using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectedCharacter : MonoBehaviour
{
    private int i;
    private int currentCharacter;

    public GameObject[] AllCharacters;

    public GameObject ArrowToLeft;
    public GameObject ArrowToRight;

    public GameObject ButtonSelectCharacter;
    public GameObject TextSelectCharacter;

    void Start()
    {
        if(PlayerPrefs.HasKey("CurrentCharacter"))
        {
            i = PlayerPrefs.GetInt("CurrentCharacter");
            currentCharacter = PlayerPrefs.GetInt("CurrentCharacter");
        }
        else
        {
            PlayerPrefs.SetInt("CurrentCharacter", i);
        }

        AllCharacters[i].SetActive(true);
        
        ButtonSelectCharacter.SetActive(false);
        TextSelectCharacter.SetActive(true);

        if(i > 0)
        {
            ArrowToLeft.SetActive(true);
        }

        if(i == AllCharacters.Length)
        {
            ArrowToRight.SetActive(false);
        }
    }

    public void ArrowRight()
    {
        if(i < AllCharacters.Length)
        {
            if(i == 0)
            {
                ArrowToLeft.SetActive(true);
            }

            AllCharacters[i].SetActive(false);
            i++;
            AllCharacters[i].SetActive(true);

            if(currentCharacter == i)
            {
                ButtonSelectCharacter.SetActive(false);
                TextSelectCharacter.SetActive(true);
            }
            else
            {
                ButtonSelectCharacter.SetActive(true);
                TextSelectCharacter.SetActive(false);
            }

            if(i + 1 == AllCharacters.Length)
            {
                ArrowToRight.SetActive(false);
            }
        }
    }

     public void ArrowLeft()
    {
        if(i < AllCharacters.Length)
        {
            AllCharacters[i].SetActive(false);
            i--;
            AllCharacters[i].SetActive(true);
            ArrowToRight.SetActive(true);

            if(currentCharacter == i)
            {
                ButtonSelectCharacter.SetActive(false);
                TextSelectCharacter.SetActive(true);
            }
            else
            {
                ButtonSelectCharacter.SetActive(true);
                TextSelectCharacter.SetActive(false);
            }

            if(i == 0)
            {
                
                ArrowToLeft.SetActive(false);
            }
        }
    }

    public void SelectCharacter()
    {
        PlayerPrefs.SetInt("CurrentCharacter", i);
        currentCharacter = i;
        ButtonSelectCharacter.SetActive(false);
        TextSelectCharacter.SetActive(true);
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(1);
    }
}