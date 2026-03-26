using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScenePlayer : MonoBehaviour
{
    [SerializeField]private GameObject cutScenePlayer;
    [SerializeField]private PlayVideo playVideo;

    [SerializeField]private bool isChapter5;
    [SerializeField]private GameObject ai;
    public void OnTriggerEnter(Collider other){
        if(other.tag=="Player"){
            cutScenePlayer.SetActive(true);
            playVideo.StartVideo();

            if(isChapter5){
                ai.SetActive(false);
            }
        }
    }
}
