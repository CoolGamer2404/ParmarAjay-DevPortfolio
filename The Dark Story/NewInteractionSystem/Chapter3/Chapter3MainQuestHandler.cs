using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interactions;

public class Chapter3MainQuestHandler : MonoBehaviour
{
    [SerializeField] private Material greenLghtMaterial;
    [SerializeField] private Material redLightMaterial;
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private Material[] material;
    void Start()
    {
        var MaterialCopy = meshRenderer.materials;
        MaterialCopy[4] = redLightMaterial;
        MaterialCopy[9] = redLightMaterial;
        MaterialCopy[8] = redLightMaterial;
        MaterialCopy[7] = redLightMaterial;
        meshRenderer.materials = MaterialCopy;
    }

    // Update is called once per frame
    void Update()
    {
        if (RayCasterChapter3.isLever1IsOn)
        {
            var MaterialCopy = meshRenderer.materials;
            MaterialCopy[4] = greenLghtMaterial;
            MaterialCopy[9] = redLightMaterial;
            MaterialCopy[8] = redLightMaterial;
            MaterialCopy[7] = redLightMaterial;
            meshRenderer.materials = MaterialCopy;
        }
        if (RayCasterChapter3.isLever2IsOn)
        {
            var MaterialCopy = meshRenderer.materials;
            MaterialCopy[4] = greenLghtMaterial;
            MaterialCopy[9] = greenLghtMaterial;
            MaterialCopy[8] = redLightMaterial;
            MaterialCopy[7] = redLightMaterial;
            meshRenderer.materials = MaterialCopy;
        }
        if (RayCasterChapter3.isLever3IsOn)
        {
            var MaterialCopy = meshRenderer.materials;
            MaterialCopy[4] = greenLghtMaterial;
            MaterialCopy[9] = greenLghtMaterial;
            MaterialCopy[8] = greenLghtMaterial;
            MaterialCopy[7] = redLightMaterial;
            meshRenderer.materials = MaterialCopy;
        }
        if (RayCasterChapter3.isLever4IsOn)
        {
            var MaterialCopy = meshRenderer.materials;
            MaterialCopy[4] = greenLghtMaterial;
            MaterialCopy[9] = greenLghtMaterial;
            MaterialCopy[8] = greenLghtMaterial;
            MaterialCopy[7] = greenLghtMaterial;
            meshRenderer.materials = MaterialCopy;
        }
    }
}
