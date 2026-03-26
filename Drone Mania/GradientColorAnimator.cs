using UnityEngine;

public class GradientColorAnimator : MonoBehaviour
{
    public Gradient emissionGradient; // The gradient to use for emission color animation
    public float duration = 5f; // Duration of the animation cycle in seconds
    private Material _material; // Reference to the material
    private float _time; // Timer to keep track of animation progress

    void Start()
    {
        // Get the material of the object
        _material = GetComponent<Renderer>().material;

        // Enable emission keyword to change emission color
        _material.EnableKeyword("_EMISSION");
    }

    void Update()
    {
        // Increment time and loop it using the duration
        _time += Time.deltaTime / duration;

        // Use Mathf.PingPong to loop the time between 0 and 1
        float t = Mathf.PingPong(_time, 1f);

        // Evaluate the gradient at time t and set it as the emission color
        Color emissionColor = emissionGradient.Evaluate(t);
        _material.SetColor("_EmissionColor", emissionColor);
    }
}
