using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;

    private Checkpoint currentCheckpoint;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public void SetCheckpoint(Checkpoint checkpoint)
    {
        currentCheckpoint = checkpoint;
    }

    public void RespawnPlayer()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

        if (playerObj != null && currentCheckpoint != null)
        {
            playerObj.transform.position = currentCheckpoint.GetPosition();

            MagneBoyController controller = playerObj.GetComponent<MagneBoyController>();
            if (controller != null)
            {
                controller.enabled=true;
                controller.Respawn();

                Rigidbody2D rb = playerObj.GetComponent<Rigidbody2D>();
                if (rb != null) rb.velocity = Vector2.zero;
            }
        }
        else{
            SceneManager.LoadScene(1);
        }
    }
}
