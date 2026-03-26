using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class PlayVideo : MonoBehaviour
{
    public RawImage rawImage;
    public VideoPlayer videoPlayer;
    public GameObject VideoPanel;
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartVideo()
    {
        rawImage.gameObject.SetActive(true);
        videoPlayer.Play();
    }
    private void OnVideoEnd(VideoPlayer source){
        VideoPanel.SetActive(false);
        videoPlayer.Stop();
    }
}
