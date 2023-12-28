using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    public Slider loading;
    public GameObject ld;
    public void PlayGame()
    {
        // in the future it will contiune from saved game
        ld.SetActive(true);
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