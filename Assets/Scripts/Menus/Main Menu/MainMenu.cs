using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Slider loading;
    public GameObject loadingContainer;
    public GameObject menu;

    public GameObject storyLoc;

    public void Story()
    {
        storyLoc.SetActive(true);
    }

    public void PlayGame()
    {
        // in the future it will contiune from saved game
        // Rogue like so no saving, except for like settings
        loadingContainer.SetActive(true);
        menu.SetActive(false);
        StartCoroutine(LoadSceneManProg());
    }

    IEnumerator LoadSceneManProg()
    {
        AsyncOperation saveop = SceneManager.LoadSceneAsync(1);
        while (!saveop.isDone)
        {
            loading.value = Mathf.Clamp01(saveop.progress / .9f);
            yield return null;
        }
    }
}