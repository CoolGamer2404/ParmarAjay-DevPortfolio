using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicsSetup : MonoBehaviour
{
    private int graphicsIndex;
    // Start is called before the first frame update
    void Start()
    {
        graphicsIndex = PlayerPrefs.GetInt("Graphics");
        QualitySettings.SetQualityLevel(graphicsIndex);
    }

    public void SetQualityToMedium()
    {
        PlayerPrefs.SetInt("Graphics",2);
        QualitySettings.SetQualityLevel(2);
    }
}
