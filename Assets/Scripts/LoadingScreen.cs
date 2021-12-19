using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    public string loadLevel;

    public GameObject loadingScreen;
    public GameObject Canvas;

    public Slider bar;

    public void Load()
    {
        Canvas.SetActive(false);
        loadingScreen.SetActive(true);

        StartCoroutine(LoadAsync());
    }

    IEnumerator LoadAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(loadLevel);

        asyncLoad.allowSceneActivation = false;

        while(!asyncLoad.isDone)
        {
            bar.value = asyncLoad.progress;

            if(asyncLoad.progress >= .9f && !asyncLoad.allowSceneActivation)
            {
                if(Input.anyKeyDown)
                {
                    asyncLoad.allowSceneActivation = true;
                }
            }

            yield return null;
        }
    }
}
