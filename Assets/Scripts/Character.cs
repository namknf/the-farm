using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private int i;
    public GameObject[] AllCharacters;

    void Start()
    {
        i = PlayerPrefs.GetInt("CurrentCharacter");
        AllCharacters[i].SetActive(true);
    }
}
