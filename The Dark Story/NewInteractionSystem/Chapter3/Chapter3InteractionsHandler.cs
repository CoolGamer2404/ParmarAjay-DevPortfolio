using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Interactions
{
    public class Chapter3InteractionsHandler : MonoBehaviour
    {


        [SerializeField] private Chapter3ObjectType chapter3Object;
        [SerializeField] private bool isInteractable = true;
        [SerializeField] private int waitTime = 5;
        [SerializeField] private InteractablesAnimationHandler _interactablesAnimationHandler;

        [SerializeField] private PlayVideo playVideo;
        [SerializeField] private TMP_Text text;
        [SerializeField] private GameObject textGameObject;

        [SerializeField] private Animator animator;

        private enum Chapter3ObjectType
        {
            Lever1,
            Lever2,
            Lever3,
            Lever4,
            MainLever,
            Door,
            Lift,
        }
        void Start()
        {
            RayCasterChapter3.isLever1IsOn = false;
            RayCasterChapter3.isLever2IsOn = false;
            RayCasterChapter3.isLever3IsOn = false;
            RayCasterChapter3.isLever4IsOn = false;
            textGameObject.SetActive(false);
            text.text = null;

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Interact()
        {
            if (chapter3Object == Chapter3ObjectType.Door)
            {
                _interactablesAnimationHandler.PlayAnimation();
            }
            if (chapter3Object == Chapter3ObjectType.Lever1 && !RayCasterChapter3.isLever1IsOn && isInteractable)
            {
                RayCasterChapter3.isLever1IsOn = true;
                StartCoroutine(Show("Lever Recovered"));
                animator.Play("LeverRecover");
                Debug.Log("E1 Recovered");
                StartCoroutine(Wait());
            }
            if (chapter3Object == Chapter3ObjectType.Lever2 && RayCasterChapter3.isLever1IsOn && !RayCasterChapter3.isLever2IsOn && isInteractable)
            {
                RayCasterChapter3.isLever2IsOn = true;
                StartCoroutine(Show("Lever Recovered"));
                animator.Play("LeverRecover");
                Debug.Log("E2 Recovered");
                StartCoroutine(Wait());
            }
            if (chapter3Object == Chapter3ObjectType.Lever3 && RayCasterChapter3.isLever2IsOn && !RayCasterChapter3.isLever3IsOn && isInteractable)
            {
                RayCasterChapter3.isLever3IsOn = true;
                StartCoroutine(Show("Lever Recovered"));
                animator.Play("LeverRecover");
                Debug.Log("E3 Recovered");
                StartCoroutine(Wait());
            }
            if (chapter3Object == Chapter3ObjectType.Lever4 && RayCasterChapter3.isLever3IsOn && !RayCasterChapter3.isLever4IsOn && isInteractable)
            {
                RayCasterChapter3.isLever4IsOn = true;
                StartCoroutine(Show("Lever Recovered"));
                animator.Play("LeverRecover");
                Debug.Log("E4 Recovered");
                StartCoroutine(Wait());
            }
            if (chapter3Object == Chapter3ObjectType.Lever1 && RayCasterChapter3.isLever1IsOn && isInteractable)
            {
                Debug.Log("E1 Is Already Recovered");
                StartCoroutine(Wait());
            }
            if (chapter3Object == Chapter3ObjectType.Lever2 && RayCasterChapter3.isLever1IsOn && RayCasterChapter3.isLever2IsOn && isInteractable)
            {
                Debug.Log("E2 Is Already Recovered");
                StartCoroutine(Wait());
            }
            if (chapter3Object == Chapter3ObjectType.Lever3 && RayCasterChapter3.isLever2IsOn && RayCasterChapter3.isLever3IsOn && isInteractable)
            {
                Debug.Log("E3 Is Already Recovered");
                StartCoroutine(Wait());
            }
            if (chapter3Object == Chapter3ObjectType.Lever4 && RayCasterChapter3.isLever3IsOn && RayCasterChapter3.isLever4IsOn && isInteractable)
            {
                Debug.Log("E4 Is Already Recovered");
                StartCoroutine(Wait());
            }
            if (chapter3Object == Chapter3ObjectType.MainLever && RayCasterChapter3.isLever4IsOn)
            {
                playVideo.StartVideo();
                return;
            }
            if (chapter3Object == Chapter3ObjectType.MainLever && !RayCasterChapter3.isLever4IsOn)
            {
                StartCoroutine(Show("Turn On All 4 Levers First !!!"));
            }
            if (chapter3Object == Chapter3ObjectType.Lift)
            {
                StartCoroutine(Show("No Electricity!!!"));
            }
            else if (isInteractable && chapter3Object != Chapter3ObjectType.Door && chapter3Object != Chapter3ObjectType.Lift)
            {
                StartCoroutine(Show("You Need To Turn On Levers In Sequence"));
                Debug.Log("Recover In Sequence");
                StartCoroutine(Wait());
            }
        }

        private IEnumerator Wait()
        {
            isInteractable = false;
            yield return new WaitForSeconds(waitTime);
            isInteractable = true;
        }
        private IEnumerator Show(string reason)
        {
            isInteractable = false;
            textGameObject.SetActive(true);
            text.text = reason;
            yield return new WaitForSeconds(waitTime);
            isInteractable = true;
            text.text = null;
            textGameObject.SetActive(false);
        }
    }
}

