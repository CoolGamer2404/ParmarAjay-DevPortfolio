using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SceneLoader : MonoBehaviour
{
    //public Slider loadingBar;
    public Image loadingbar;

    public void LoadSceneAsync(int SceneNumber)
    {
        StartCoroutine(LoadAsync(SceneNumber));
    }

    public void LoadSceneNo(int SceneIndexToLoad){
        StartCoroutine(LoadAsync(SceneIndexToLoad));
    }

    private IEnumerator LoadAsync(int SceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneIndex);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            loadingbar.fillAmount=progress;

            yield return null;
        }
    }
}
