using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Xml.Linq;

public class TaskTextHandler : MonoBehaviour
{
    public float letterDelay = 0.1f;
    public float eraseDelay = 2f;
    public string lightActivatedText = "Lights Turned On " + lightsActivated.ToString() + "/3";
    public string documentsCollectedText = "Documents Collected " + documentsCollected.ToString() + "/5";
    public static int lightsActivated;
    public static int documentsCollected;
    public bool allLightsActivated;
    public bool allDocumentsCollected;

    public bool isLightsActivatedWritten = false;
    public bool isDocumentsCollectedWritten = false;

    [SerializeField] private TMP_Text textComponent;
    private string currentText = "";
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip typingSoundEffectClip;
    //pu TextType textType;
    //[SerializeField] private BoxCollider entranceCollider;

    public enum TextType
    {
        lightsText,
        documentsText,
    }

    // Start is called before the first frame update
    void Start()
    {
        lightsActivated=0;
        documentsCollected=0;
        isLightsActivatedWritten = false;
        textComponent.text = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (isLightsActivatedWritten == false)
        {
            lightActivatedText = "Lights Turned On " + lightsActivated.ToString() + "/3";
        }
        if(isDocumentsCollectedWritten == false)
        {
            documentsCollectedText= "Documents Collected " + documentsCollected.ToString() + "/5";
        }
        if (lightsActivated == 3 && allLightsActivated==false)
        {
            StartCoroutine(LightsActivated());
            allLightsActivated = true;
        }

        if(documentsCollected==5 && allDocumentsCollected == false)
        {
            StartCoroutine(DocumentsCollected());
            allDocumentsCollected = true;
        }
        if (isLightsActivatedWritten == true)
        {
            textComponent.text = "Lights Turned On "+lightsActivated.ToString()+"/3";
        }
        if (isDocumentsCollectedWritten == true)
        {
            textComponent.text = "Documents Collected " + documentsCollected.ToString() + "/5";
        }
    }

    IEnumerator WriteText(string fullText,TextType type)
    {
        for (int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            textComponent.text = currentText;
            audioSource.PlayOneShot(typingSoundEffectClip);
            yield return new WaitForSeconds(letterDelay);
            if (currentText == fullText && type==TextType.documentsText)
            {
                isDocumentsCollectedWritten = true;
                StopAllCoroutines();
            }
            else if(currentText==fullText && type == TextType.lightsText)
            {
                isLightsActivatedWritten = true;
                StopAllCoroutines();
            }
        }
    }

    IEnumerator EraseText(string fullText)
    {
        for (int i = fullText.Length; i >= 0; i--)
        {
            currentText = fullText.Substring(0, i);
            textComponent.text = currentText;
            yield return new WaitForSeconds(letterDelay);
            textComponent.fontStyle &= ~FontStyles.Strikethrough;
            if (documentsCollected != 5 && string.IsNullOrEmpty(textComponent.text))
            {
                StartCoroutine(WriteText(documentsCollectedText,TextType.documentsText));
            }
        }
    }

    public void WriteNewText()
    {
        StartCoroutine(WriteText(lightActivatedText, TextType.lightsText));
    }

    public void EnableStrikethrough()
    {
        textComponent.fontStyle |= FontStyles.Strikethrough;
    }

    public void DisableStrikethrough()
    {
        textComponent.fontStyle &= ~FontStyles.Strikethrough;
    }

    IEnumerator LightsActivated()
    {
        textComponent.fontStyle |= FontStyles.Strikethrough;
        yield return new WaitForSeconds(eraseDelay);
        isLightsActivatedWritten = false;
        StartCoroutine(EraseText("Lights Turned On " + lightsActivated.ToString() + "/3"));
    }
    IEnumerator DocumentsCollected()
    {
        textComponent.fontStyle |= FontStyles.Strikethrough;
        yield return new WaitForSeconds(eraseDelay);
        isDocumentsCollectedWritten = false;
        StartCoroutine(EraseText("Documents Collected " + documentsCollected.ToString() + "/5"));
    }
}
