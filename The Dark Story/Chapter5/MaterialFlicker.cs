using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MaterialFlicker : MonoBehaviour
{
    [SerializeField]private Material material;
    [SerializeField]private Vector4 emissionIntensityColor1;
    [SerializeField]private Vector4 emissionIntensityColor2;
    [SerializeField]private float emissionIntensity1;
    [SerializeField]private float emissionIntensity2;
    [ColorUsage(true,true)]
    [SerializeField]private Color redColor;
    

    // Start is called before the first frame update
    void Start()
    {
        material.SetColor("_EmissionColor",redColor*emissionIntensityColor1*emissionIntensity1);
    }

    public void ChangeColorFirst(){
        material.SetColor("_EmissionColor",redColor*emissionIntensityColor1*emissionIntensity1);
    }
    public void ChangeColorSecond(){
        material.SetColor("_EmissionColor",redColor*emissionIntensityColor2*emissionIntensity2);
    }
}
