using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class TheMaze : MonoBehaviour
{
    /*
     *1)Time Limit
     *2)Traps
     *3)JumpScare
    */

    [SerializeField] private float GameTime;
    [SerializeField] private GameObject TrapWall1;
    [SerializeField] private GameObject TrapWall2;
    [SerializeField] private GameObject TrapWall3;

    [SerializeField] private AudioSource A1;
    [SerializeField] private AudioSource A2;
    [SerializeField] private AudioSource A3;
    [SerializeField] private AudioClip trap;
    [SerializeField] private GameObject deathUI;
    [SerializeField] private Escape escape;
    [SerializeField] private StarterAssetsInputs starterAssetsInputs;

    public static int currenttrapnum = 0;

    // Start is called before the first frame update
    void Start()
    {
        TrapWall1.SetActive(false);
        TrapWall2.SetActive(false);
        TrapWall3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Time Limit
        //GameTime -= Time.deltaTime;
        /*if (GameTime <= 0)
        {
            //Debug.Log("GameOver!!");
            deathUI.SetActive(true);
            escape.isdmenuActive = true;
            starterAssetsInputs.cursorLocked = false;
            starterAssetsInputs.cursorInputForLook = false;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }*/
        if (currenttrapnum != 0)
        {
            TurnOnTrap();
            Debug.Log("----------------------------Die1---------------------------");
        }
    }
    public void TurnOnTrap()
    {
        if (currenttrapnum == 1)
        {
            TrapWall1.SetActive(true);
            A1.PlayOneShot(trap);
            Debug.Log("GameOver");
            GameTime -= Time.deltaTime;
            currenttrapnum = 0;
            StartCoroutine(StartTimer());
            return;
        }
        if (currenttrapnum == 2)
        {
            TrapWall2.SetActive(true);
            A2.PlayOneShot(trap);
            Debug.Log("GameOver");
            GameTime -= Time.deltaTime;
            currenttrapnum = 0;
            StartCoroutine(StartTimer());
            return;
        }
        if (currenttrapnum == 3)
        {
            TrapWall3.SetActive(true);
            A3.PlayOneShot(trap);
            Debug.Log("GameOver");
            GameTime -= Time.deltaTime;
            currenttrapnum = 0;
            StartCoroutine(StartTimer());
            return;
        }
    }
    public void ResetDeathTime()
    {
        GameTime = 20f;
        Debug.Log("----------------------------Die3---------------------------");
        return;
    }
    public IEnumerator StartTimer()
    {
        Debug.Log("----------------------------Die2---------------------------");
        yield return new WaitForSeconds(GameTime);
        deathUI.SetActive(true);
        currenttrapnum = 0;
        escape.isdmenuActive = true;
        starterAssetsInputs.cursorLocked = false;
        starterAssetsInputs.cursorInputForLook = false;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
}
