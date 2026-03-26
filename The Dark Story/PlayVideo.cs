using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using StarterAssets;

public class PlayVideo : MonoBehaviour
{
    public RawImage rawImage;
    public VideoPlayer videoPlayer;
    public Button skipButton;
    public GameObject skipButtonContainer;

    [SerializeField] private InputActionAsset inputActionAsset;
    [SerializeField] private InputAction skipAction;
    [SerializeField] private string targetInputActionAssetName = "StarterAssets";
    [SerializeField] private InputActionAsset[] allAssets;

    [SerializeField] private bool isEnding;
    [SerializeField] private bool isStarting;

    [SerializeField] private SceneLoader sceneLoader;

    [SerializeField] private AudioSource audioSource;

    [SerializeField] private GameObject SceneLoaderGameObject;
    [SerializeField] private int _currentChapter;

    public StarterAssetsInputs StarterAssetsInputs;

    //public RewardedAdManager rewardedAdManager;

    private bool skipButtonVisible = false;

    private void Start()
    {
        videoPlayer.loopPointReached += OnVideoEnd;
        skipButton.onClick.AddListener(SkipVideo);

        allAssets = Resources.FindObjectsOfTypeAll<InputActionAsset>();
        foreach (InputActionAsset asset in allAssets)
        {
            if (asset.name == targetInputActionAssetName)
            {
                inputActionAsset = asset;
            }
        }
        skipAction = inputActionAsset.FindAction("Skip");
        skipAction.Enable();

        HideSkipButton();
    }

    public void StartVideo()
    {
        audioSource.Stop();
        rawImage.gameObject.SetActive(true);
        videoPlayer.Play();
        if (isEnding)
        {
            StarterAssetsInputs.cursorLocked = false;
            StarterAssetsInputs.cursorInputForLook = false;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            if(_currentChapter==1){
                PlayerPrefs.SetInt("Chapter1",1);
            }
            if(_currentChapter==2){
                PlayerPrefs.SetInt("Chapter2",1);
            }
            if(_currentChapter==3){
                PlayerPrefs.SetInt("Chapter3",1);
            }
            if(_currentChapter==4){
                PlayerPrefs.SetInt("Chapter4",1);
            }
            if(_currentChapter==5){
                PlayerPrefs.SetInt("Chapter5",1);
            }
        }

    }

    private void Update()
    {
        if (videoPlayer.isPlaying && !skipButtonVisible)
        {
            float videoProgress = (float)videoPlayer.time / (float)videoPlayer.clip.length;
            if (videoProgress >= 0.2f)
            {
                ShowSkipButton();
            }
        }
        if (skipButton.interactable && skipAction.triggered)
        {
            SkipVideo();
        }
    }

    private void OnVideoEnd(VideoPlayer source)
    {
        ShowSkipButton();
        if (isEnding)
        {
            SceneLoaderGameObject.SetActive(true);
            sceneLoader.LoadSceneAsync(0);
        }
        if (isStarting)
        {
            SceneLoaderGameObject.SetActive(true);
            sceneLoader.LoadSceneAsync(1);
        }
        if(!isEnding&&!isStarting){
            videoPlayer.gameObject.SetActive(false);
        }
        //rewardedAdManager.ShowRewardedAd();
    }

    private void ShowSkipButton()
    {
        skipButtonContainer.SetActive(true);
        skipButton.interactable = true;
        skipButtonVisible = true;
    }

    private void HideSkipButton()
    {
        skipButtonContainer.SetActive(false);
        skipButton.interactable = false;
        skipButtonVisible = false;
    }

    private void SkipVideo()
    {
        videoPlayer.Stop();
        HideSkipButton();
        if (isEnding)
        {
            SceneLoaderGameObject.SetActive(true);
            sceneLoader.LoadSceneAsync(0);
        }
        if (isStarting)
        {
            SceneLoaderGameObject.SetActive(true);
            sceneLoader.LoadSceneAsync(1);
        }
        //rewardedAdManager.ShowRewardedAd();
    }
}
