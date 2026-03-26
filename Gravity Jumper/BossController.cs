using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 2f;
    public Transform leftBoundary;
    public Transform rightBoundary;

    [Header("Shooting")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float shootInterval = 3f;
    public float timeBetweenBurstShots = 0.2f;
    public int minBulletsPerBurst = 3;
    public int maxBulletsPerBurst = 5;

    [Header("Health")]
    public int maxHealth = 10;
    private int currentHealth;

    [Header("Visuals")]
    public SpriteRenderer sr;
    public float blinkDuration = 0.1f;

    [Header("Camera Zoom")]
    public Camera mainCamera;
    public float zoomedOutSize = 8f;
    public float normalZoomSize = 5f;
    public float zoomSpeed = 2f;

    public bool fightStarted = false;
    public bool fightPaused = false;

    private Transform player;
    private Vector2 moveDirection = Vector2.right;
    private Rigidbody2D rb;

    public GameObject creditUI;

    private float shootTimer = 0f;

    private void Start()
    {
        currentHealth = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        rb = GetComponent<Rigidbody2D>();

        if (mainCamera == null)
            mainCamera = Camera.main;
    }

    private void Update()
    {
        if (!fightStarted || fightPaused) return;

        Move();
        FacePlayer();
        HandleShooting();
        HandleCameraZoom(zoomedOutSize);
    }

    private void Move()
    {
        if (leftBoundary == null || rightBoundary == null) return;

        // Move boss
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // Wall detection using raycast
        RaycastHit2D hit = Physics2D.Raycast(transform.position, moveDirection, 0.5f, LayerMask.GetMask("Ground"));

        if (hit.collider != null || transform.position.x < leftBoundary.position.x)
        {
            moveDirection = Vector2.right;
        }
        else if (transform.position.x > rightBoundary.position.x)
        {
            moveDirection = Vector2.left;
        }
    }

    private void HandleShooting()
    {
        shootTimer += Time.deltaTime;

        if (shootTimer >= shootInterval)
        {
            shootTimer = 0f;
            int bulletsToShoot = Random.Range(minBulletsPerBurst, maxBulletsPerBurst + 1);
            StartCoroutine(ShootBurst(bulletsToShoot));
        }
    }

    IEnumerator ShootBurst(int count)
    {
        for (int i = 0; i < count; i++)
        {
            if (bulletPrefab != null && firePoint != null && player != null)
            {
                Vector2 direction = (player.position - firePoint.position).normalized;

                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
                Bullet bulletScript = bullet.GetComponent<Bullet>();

                if (bulletScript != null)
                {
                    bulletScript.direction = direction;
                    bulletScript.speed = bulletScript.speed;
                }
            }

            yield return new WaitForSeconds(timeBetweenBurstShots);
        }
    }

    private void FacePlayer()
    {
        if (player == null) return;

        Vector3 scale = transform.localScale;

        if (player.position.x < transform.position.x)
            scale.x = -Mathf.Abs(scale.x);
        else
            scale.x = Mathf.Abs(scale.x);

        transform.localScale = scale;
    }

    private void HandleCameraZoom(float targetSize)
    {
        if (mainCamera != null)
        {
            mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, targetSize, Time.deltaTime * zoomSpeed);
        }
    }

    // === Public Control ===

    public void EnableBossFight()
    {
        if (fightStarted) return;

        fightStarted = true;
        fightPaused = false;
    }

    public void HoldBossFight()
    {
        //fightPaused = true;
        //HandleCameraZoom(normalZoomSize);
    }

    public void ResumeBossFight()
    {
        //fightPaused = false;
        //HandleCameraZoom(zoomedOutSize);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        StartCoroutine(BlinkRed());

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    IEnumerator BlinkRed()
    {
        if (sr != null)
        {
            sr.color = Color.red;
            yield return new WaitForSeconds(blinkDuration);
            sr.color = Color.white;
        }
    }

    private void Die()
    {
        Debug.Log("Boss defeated.");
        creditUI.SetActive(true);
        gameObject.SetActive(false);
    }
}
