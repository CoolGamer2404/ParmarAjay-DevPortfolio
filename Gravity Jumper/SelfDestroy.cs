using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    public float timer = 2f;
    public bool destroyOnStart = false;

    void Start()
    {
        if (destroyOnStart)
        {
            StartCoroutine(DestroyAfterDelay());
        }
    }

    public void SelfDestroyNow()
    {
        StartCoroutine(DestroyAfterDelay());
    }

    private System.Collections.IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(timer);
        Destroy(gameObject);
    }
}
