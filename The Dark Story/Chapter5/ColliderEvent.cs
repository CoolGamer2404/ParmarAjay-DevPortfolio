using UnityEngine;
using UnityEngine.Events;

public class ColliderEvent : MonoBehaviour
{
    public TaskTextHandler taskTextHandler;

    public GameObject fallingObjectsJumpScare;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            taskTextHandler.WriteNewText();
            fallingObjectsJumpScare.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}