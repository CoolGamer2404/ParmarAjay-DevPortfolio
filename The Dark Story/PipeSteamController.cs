using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
//using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

namespace Interactions
{
    public class PipeSteamController : MonoBehaviour
    {
        public float distance;
        public Transform PlayerCamera;
        public static bool InteractableWithpipe;
        public float InteractionRange;
        public Transform PipeGameobject;
        public Animator PipeAnimator;

        public bool IsOneSided;
        [SerializeField] private GameObject SteamControlller;
        [SerializeField] private bool isleft;
        [SerializeField] private bool isopen;
        [SerializeField] private int WaitTime=2;
        [SerializeField] private bool caninteract;

        // Update is called once per frame
        /*void Update()
        {
            Vector3 distanceToPlayer = PlayerCamera.transform.position - transform.position;

            if (distanceToPlayer.magnitude <= InteractionRange)
            {
                InteractableWithpipe = true;
            }
            if (distanceToPlayer.magnitude >= InteractionRange)
            {
                InteractableWithpipe = false;
            }

            if (InteractableWithpipe == true)
            {
                RayCast();
            }
        }

        void RayCast()
        {
            RaycastHit pipehit;
            if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out pipehit, distance))
            {
                if (pipehit.transform.tag == "Pipe")
                {
                    PipeGameobject = pipehit.transform;
                    PipeAnimator = pipehit.transform.GetComponentInParent<Animator>();
                    if (CrossPlatformInputManager.GetButtonDown("ItemUse"))
                    {
                        Interact();
                    }
                }
                else
                {
                    PipeGameobject = null;
                }
            }
        }*/
        public void Interact()
        {
            if (IsOneSided == true)
            {
                isopen = PipeAnimator.GetBool("isOpen");
                if (isopen == true && caninteract)
                {
                    PipeAnimator.SetBool("isOpen", false);
                    StartCoroutine(Wait());
                    return;
                }
                if (isopen == false && caninteract)
                {
                    PipeAnimator.SetBool("isOpen", true);
                    StartCoroutine(Wait());
                    return;
                }
            }
            if (IsOneSided == false)
            {
                isleft = PipeAnimator.GetBool("isLeft");
                if (isleft == false && caninteract)
                {
                    PipeAnimator.SetBool("isLeft", true);
                    StartCoroutine(Wait());
                    return;
                }
                if (isleft == true && caninteract)
                {
                    PipeAnimator.SetBool("isLeft", false);
                    StartCoroutine(Wait());
                    return;
                }
            }
        }
        private IEnumerator Wait(){
            caninteract=false;
            yield return new WaitForSeconds(WaitTime);
            caninteract=true;
        }
    }

}