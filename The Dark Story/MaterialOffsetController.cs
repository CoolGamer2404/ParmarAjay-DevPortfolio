using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialOffsetController : MonoBehaviour
{
    public float scrollSpeed = 0.5f; // Adjust the scrolling speed

    [SerializeField]private Renderer _renderer;
    [SerializeField] private Material _material;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _material = _renderer.material;
    }

    private void Update()
    {
        // Calculate the new offset based on time and speed
        Vector2 offset = new Vector2(Time.time * scrollSpeed, 0);

        // Apply the offset to the material
        _material.mainTextureOffset = offset;
    }
}
