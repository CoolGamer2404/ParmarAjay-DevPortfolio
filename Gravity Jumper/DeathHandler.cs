using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathHandler : MonoBehaviour
{
    public static DeathHandler Instance;

    public BossController boss;

    [Header("Death Panel")]
    public GameObject youDiedPanel;

    [Header("Health")]
    public int maxHearts = 3;
    public int currentHearts;

    public Image[] heartImages; // Assign Heart1, Heart2, Heart3 in Inspector

    private MagneBoyController playerController;
    private Animator animator;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        currentHearts = maxHearts;

        playerController = GetComponent<MagneBoyController>();
        animator = GetComponent<Animator>();

        if (youDiedPanel != null)
            youDiedPanel.SetActive(false);

        UpdateHeartUI();
    }

    public void TakeDamage(int amount, bool trueDamage)
    {
        if (currentHearts <= 0 || playerController.IsInvincible() && trueDamage == false)
            return;

        currentHearts -= amount;
        currentHearts = Mathf.Clamp(currentHearts, 0, maxHearts);

        UpdateHeartUI();

        playerController.TriggerHurtFeedback(); // blinking + i-frames

        if (currentHearts <= 0)
        {
            TriggerDeath();
        }
        else
        {
            if (animator != null)
            {
                animator.SetTrigger("Hurt");
            }
        }
    }

    public void UpdateHeartUI()
    {
        for (int i = 0; i < heartImages.Length; i++)
        {
            if (heartImages[i] != null)
                heartImages[i].enabled = i < currentHearts;
        }
    }

    public void TriggerDeath()
    {
        if (playerController != null)
            playerController.enabled = false;

        if (animator != null)
            animator.enabled = false;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;
        }

        Collider2D col = GetComponent<Collider2D>();
        if (col != null)
            col.enabled = false;

        if (youDiedPanel != null)
            youDiedPanel.SetActive(true);

        boss.HoldBossFight();
    }

    public void LoadSceneWithNumber(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
