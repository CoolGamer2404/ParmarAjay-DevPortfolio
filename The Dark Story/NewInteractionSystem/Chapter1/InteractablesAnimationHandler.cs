using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace Interactions
{
    public class InteractablesAnimationHandler : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private bool isOpen;

        [SerializeField] private string openanimationName = "InteractableOpen";
        [SerializeField] private string closeanimationName = "InteractableClose";
        [SerializeField] private int timeToShowUI = 3;
        [SerializeField] private GameObject showLockedUi = null;
        [SerializeField] private int waitTimer = 1;
        [SerializeField] private bool pauseInteraction = false;

        [Header("---------------------Music---------------------")]
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip audioClip;
        [SerializeField] private AudioClip unlockAudioClip;


        [Header("---------------------OnlyForJumpscareTrigger---------------------")]
        [SerializeField] private bool isJumpscareTriggeres = false;
        [SerializeField] private PlayableDirector PlayableDirector;

        /*private void Awake(){
            animator=gameObject.GetComponent<Animator>();
        }*/

        private IEnumerator pauseInteractions()
        {
            pauseInteraction = true;
            yield return new WaitForSeconds(waitTimer);
            pauseInteraction = false;
        }

        public void PlayAnimation()
        {
            if (!isOpen && !pauseInteraction)
            {
                animator.Play(openanimationName, 0, 0.0f);
                isOpen = true;
                StartCoroutine(pauseInteractions());
            }
            if (isOpen && !pauseInteraction)
            {
                animator.Play(closeanimationName, 0, 0.0f);
                isOpen = false;
                StartCoroutine(pauseInteractions());
            }
        }
        public void ShowItIsLocked()
        {

        }
        private IEnumerator ShowLockedUi()
        {
            showLockedUi.SetActive(true);
            yield return new WaitForSeconds(timeToShowUI);
            showLockedUi.SetActive(false);
        }

        public void PlayMusic()
        {
            audioSource.PlayOneShot(audioClip);
            return;
        }

        public void PlayUnlockMusic()
        {
            audioSource.PlayOneShot(unlockAudioClip);
            if (isJumpscareTriggeres)
            {
                PlayableDirector.Play();
            }
            return;
        }

        public void AIEnter()
        {
            if (isOpen == false)
            {
                animator.Play(openanimationName,0,0.0f);
                isOpen = true;
                return;
            }
            if (isOpen == true)
            {
                return;
            }
        }
        public void AIExit()
        {
            if (isOpen == true)
            {
                animator.Play(closeanimationName,0,0.0f);
                isOpen = false;
                return;
            }
            if (isOpen == false)
            {
                return;
            }
        }
    }
}