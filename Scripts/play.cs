using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class play: MonoBehaviour
{
    public GameObject UIbag;//背包界面
    public GameObject UIRed;//设置界面


    public GameObject load;
//    public GameObject loadingScreen;
    public Slider slider;

    public void LoadLevel(int sceneIndex)
    {
        load.SetActive(true);
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("tingzi");

 //       loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            slider.value = progress;


            yield return null;   // wait a frame, and do it again
        }
    }



    // Start is called before the first frame update
    public void red()
    {
        UIRed.SetActive(true);
    }
    public void obag()
    {
        UIbag.SetActive(true);
    }
    public void uiExit()
    {
        UIRed.SetActive(false);
    }
    public void xbag()
    {
        UIbag.SetActive(false);
    }
    public void gameExit()
    {
        Application.Quit();
    }
}
