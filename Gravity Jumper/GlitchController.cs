using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class GlitchController : MonoBehaviour
{
    [Range(0f, 1f)]
    public float glitchStrength = 0f;

    private MaterialPropertyBlock mpb;
    private SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        mpb = new MaterialPropertyBlock();
    }

    private void Update()
    {
        sr.GetPropertyBlock(mpb);
        mpb.SetFloat("_GlitchStrength", glitchStrength);
        sr.SetPropertyBlock(mpb);
    }

    public void SetGlitch(float strength)
    {
        glitchStrength = Mathf.Clamp01(strength);
    }

    public void GlitchPulse(float strength, float duration)
    {
        StopAllCoroutines();
        StartCoroutine(GlitchForTime(strength, duration));
    }

    private System.Collections.IEnumerator GlitchForTime(float strength, float duration)
    {
        glitchStrength = strength;
        yield return new WaitForSeconds(duration);
        glitchStrength = 0f;
    }
}
