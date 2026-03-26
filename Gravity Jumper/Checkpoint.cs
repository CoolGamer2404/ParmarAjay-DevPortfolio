using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [Header("Visuals")]
    public GameObject inactiveVisual;
    public GameObject activeVisual;

    private bool isActivated = false;

    void Start()
    {
        UpdateVisual();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isActivated && other.CompareTag("Player"))
        {
            isActivated = true;
            SaveManager.instance.SetCheckpoint(this);
            UpdateVisual();

            MagneBoyController player = other.GetComponent<MagneBoyController>();
            if (player != null)
                player.RestoreToFullHealth();
        }
    }

    public void UpdateVisual()
    {
        if (inactiveVisual != null)
            inactiveVisual.SetActive(!isActivated);

        if (activeVisual != null)
            activeVisual.SetActive(isActivated);
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}
