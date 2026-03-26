using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SceneLoader : MonoBehaviour
{
    //public Slider loadingBar;
    public Text loadingText;
    public Image loadingImage;

    [SerializeField]private bool itsEndingScreen;
    [SerializeField] private int CurrentScene;

    public Sprite[] loadingImages;  // Array of loading screen images
    private int currentImageIndex = 0;

    public void LoadSceneAsync(int SceneNumber)
    {
        StartCoroutine(LoadAsync(SceneNumber));
        if(itsEndingScreen){
            if(CurrentScene==1){
                PlayerPrefs.SetInt("FinishedChapter_"+CurrentScene,1);
                PlayerPrefs.SetInt("UnlockedChapter_"+2,1);
            }
            if(CurrentScene==2){
                PlayerPrefs.SetInt("FinishedChapter_"+CurrentScene,1);
            }
        }
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
            //loadingBar.value = progress;
            loadingText.text = "Loading: " + (progress * 100).ToString("F0") + "%";

            // Change the loading image sequentially
            //loadingImage.sprite = loadingImages[currentImageIndex];
            //currentImageIndex = (currentImageIndex + 1) % loadingImages.Length;

            yield return null;
        }
    }
}
