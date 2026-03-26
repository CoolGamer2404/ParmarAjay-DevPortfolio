using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChapterSelection : MonoBehaviour
{
    public Scrollbar scrollbar;
    public Button[] buttons;
    public Image[] locks;
    float scroll_pos = 0;
    float[] pos;

    public Sprite LockedButton;
    public Sprite PlayButton;
    public Sprite ComingSoonButton;

    private int currentChapter = 1; // Track the current chapter reached by the player

    public SceneLoader sceneLoader;
    public GameObject SceneLoaderGameObject;
    public GameObject ChapterSelectionPanel;

    public GameObject chapter2Lock;
    public Button chapter2Button;
    public GameObject chapter3Lock;
    public Button chapter3Button;
    public GameObject chapter4Lock;
    public Button chapter4Button;
    public GameObject chapter5Lock;
    public Button chapter5Button;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if(PlayerPrefs.GetInt("Chapter1")==1){
            chapter2Lock.SetActive(false);
            chapter2Button.interactable=true;
            chapter2Button.gameObject.GetComponent<Image>().sprite=PlayButton;
        }
        if(PlayerPrefs.GetInt("Chapter2")==1){
            chapter3Lock.SetActive(false);
            chapter3Button.interactable=true;
            chapter3Button.gameObject.GetComponent<Image>().sprite=PlayButton;
        }
        if(PlayerPrefs.GetInt("Chapter3")==1){
            chapter4Lock.SetActive(false);
            chapter4Button.interactable=true;
            chapter4Button.gameObject.GetComponent<Image>().sprite=PlayButton;
        }
        if(PlayerPrefs.GetInt("Chapter4")==1){
            chapter5Lock.SetActive(false);
            chapter5Button.interactable=true;
            chapter5Button.gameObject.GetComponent<Image>().sprite=PlayButton;
        }
        if(PlayerPrefs.GetInt("Chapter1")==0){
            chapter2Lock.SetActive(true);
            chapter2Button.interactable=false;
            chapter2Button.gameObject.GetComponent<Image>().sprite=LockedButton;
        }
        if(PlayerPrefs.GetInt("Chapter2")==0){
            chapter3Lock.SetActive(true);
            chapter3Button.interactable=false;
            chapter3Button.gameObject.GetComponent<Image>().sprite=LockedButton;
        }
        if(PlayerPrefs.GetInt("Chapter3")==0){
            chapter4Lock.SetActive(true);
            chapter4Button.interactable=false;
            chapter4Button.gameObject.GetComponent<Image>().sprite=LockedButton;
        }
        if(PlayerPrefs.GetInt("Chapter4")==0){
            chapter5Lock.SetActive(true);
            chapter5Button.interactable=false;
            chapter5Button.gameObject.GetComponent<Image>().sprite=LockedButton;
        }

        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);
        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }

        if (Input.GetMouseButton(0))
        {
            scroll_pos = scrollbar.GetComponent<Scrollbar>().value;
        }
        else
        {
            for (int i = 0; i < pos.Length; i++)
            {
                if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
                {
                    scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[i], 0.1f);
                }
            }
        }

        for (int i = 0; i < pos.Length; i++)
        {
            if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
            {
                transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(1f, 1f), 0.1f);
                buttons[i].transform.gameObject.SetActive(true);
                for (int a = 0; a < pos.Length; a++)
                {
                    if (a != i)
                    {
                        transform.GetChild(a).localScale = Vector2.Lerp(transform.GetChild(a).localScale, new Vector2(0.8f, 0.8f), 0.1f);
                        buttons[a].transform.gameObject.SetActive(false);
                    }
                }
            }
        }
    }

    private void SaveChapterProgress()
    {
        PlayerPrefs.SetInt("CurrentChapter", currentChapter);
        PlayerPrefs.Save();
    }
}
