using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class DayAndNightHandler : MonoBehaviour
{
    [Header("Gradient")]
    [SerializeField]private Gradient fogGradient;
    [SerializeField]private Gradient ambientGradient;
    [SerializeField]private Gradient directionLightColor;
    [SerializeField]private Gradient skyboxTintColor;


    [Header("EnvironmentAssets")]
    [SerializeField]private Light directionLight;
    [SerializeField]private Material skyboxMaterial;

    [Header("Variables")]
    [SerializeField]private float dayDuration=60f;
    [SerializeField]private float rotationSpeed=1f;

    public Volume bloomVolume;

    private float currentTime=0f;

    public Text text;

    private void Update(){
        UpdateTime();
        UpdateDayNightCycle();
        RotateSkybox();
    }

    private void UpdateTime(){
        currentTime+=Time.deltaTime/dayDuration;
        currentTime=Mathf.Repeat(currentTime,1f);
        text.text=currentTime.ToString();
        if(currentTime>=0.25f && currentTime<=.70f && bloomVolume.weight<=1f){
            bloomVolume.weight+=Time.smoothDeltaTime*0.25f;
        }
        if(currentTime>=0.70f&& bloomVolume.weight>=0f){
            bloomVolume.weight-=Time.smoothDeltaTime*0.25f;
        }
    }

    private void UpdateDayNightCycle(){
        float sunPosition=Mathf.Repeat(currentTime+0.25f,1f);
        directionLight.transform.rotation=Quaternion.Euler(sunPosition*360f,0f,0f);

        RenderSettings.fogColor=fogGradient.Evaluate(currentTime);
        RenderSettings.ambientLight=ambientGradient.Evaluate(currentTime);

        directionLight.color=directionLightColor.Evaluate(currentTime);

        skyboxMaterial.SetColor("_Tint",skyboxTintColor.Evaluate(currentTime));
    }

    private void RotateSkybox(){
        float currentRotation=skyboxMaterial.GetFloat("_Rotation");
        float newRotation=currentRotation+rotationSpeed*Time.deltaTime;

        newRotation=Mathf. Repeat(newRotation,360f);
        skyboxMaterial.SetFloat("_Rotation",newRotation);
    }

    private void OnApplicationQuit(){
        skyboxMaterial.SetColor("_Tint",new Color(0.5f,0.5f,0.5f));
    }
}
