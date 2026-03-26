using UnityEngine;
using System.Collections;

public class MagneBoyController : MonoBehaviour
{
    [Header("Health")]
    public int maxHealth = 3;
    public int currentHealth;
    private bool isDead = false;

    [Header("Movement")]
    public float moveSpeed = 6f;
    public float jumpForce = 14f;

    [Header("Gravity")]
    public float gravityScale = 3f;
    public float gravityFlipCooldown = 0.5f;
    private float lastFlipTime = -999f;
    private bool isFlipped = false;
    private bool pendingFlip = false;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float checkRadius = 0.15f;
    public LayerMask groundLayer;

    [Header("Shooting")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;
    private bool isShooting = false;

    [Header("Damage Feedback")]
    public SpriteRenderer spriteRenderer;
    public float invincibilityDuration = 1.5f;
    public float blinkDuration = 0.1f;

    private bool isInvincible = false;

    [Header("Ability Invincibility")]
    public bool isAbilityInvincible = false;

    [SerializeField] private bool isGrounded;
    [SerializeField] private bool isOnMagneticPlatform = false;

    private Rigidbody2D rb;
    private CapsuleCollider2D col;
    private Vector3 originalScale;
    private int lastDirectionFaced = 1;

    [SerializeField] private MasterPlatform currentPlatform;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();

        originalScale = transform.localScale;
        rb.gravityScale = gravityScale;

        rb.interpolation = RigidbodyInterpolation2D.Interpolate;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rb.freezeRotation = true;

        currentHealth = maxHealth;
    }

    void Update()
    {
        if (isDead) return;

        HandleInput();
        HandleVisualFlip();
        UpdateAnimatorStates();
    }

    void FixedUpdate()
    {
        if (isDead) return;

        CheckGrounded();

        if (currentPlatform != null && currentPlatform.isMoving && isGrounded)
        {
            transform.position += (Vector3)currentPlatform.platformVelocity * Time.fixedDeltaTime;
        }

        HandleMovement();
    }

    void HandleInput()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            float jumpVelocity = isFlipped ? -jumpForce : jumpForce;
            rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);

            if (pendingFlip)
            {
                ApplyVisualFlip();
                pendingFlip = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            TryFlipGravity();
        }

        if (Input.GetKeyDown(KeyCode.K) && !isShooting)
        {
            isShooting = true;
            anim.SetTrigger("Shoot");
        }
    }

    public void FireBullet()
    {
        AudioManager.instance.PlayShoot();
        Vector2 direction = new Vector2(lastDirectionFaced, 0);
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.direction = direction;
        bulletScript.speed = bulletSpeed;

        isShooting = false;
    }

    void TryFlipGravity()
    {
        if (Time.time - lastFlipTime < gravityFlipCooldown)
            return;

        isFlipped = !isFlipped;
        lastFlipTime = Time.time;

        GameManager.instance.SetGravityFlipped(isFlipped);
        AudioManager.instance.PlayGravityChange();

        if (currentPlatform != null && currentPlatform.isMagnetic && currentPlatform.isSticking)
        {
            pendingFlip = true;
        }
        else
        {
            ApplyVisualFlip();
        }
    }

    void ApplyVisualFlip()
    {
        rb.gravityScale = isFlipped ? -gravityScale : gravityScale;

        Vector3 newScale = originalScale;
        newScale.y *= isFlipped ? -1 : 1;
        transform.localScale = new Vector3(
            lastDirectionFaced * Mathf.Abs(newScale.x),
            newScale.y,
            newScale.z
        );
    }

    void HandleVisualFlip()
    {
        float dir = Input.GetAxisRaw("Horizontal");

        if (dir != 0)
        {
            lastDirectionFaced = (int)Mathf.Sign(dir);
            transform.localScale = new Vector3(
                lastDirectionFaced * Mathf.Abs(originalScale.x),
                transform.localScale.y,
                transform.localScale.z
            );
        }
    }

    void HandleMovement()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        float targetXVelocity = moveInput * moveSpeed;
        float yVelocity = rb.velocity.y;

        rb.velocity = new Vector2(targetXVelocity, yVelocity);
    }

    void CheckGrounded()
    {
        if (groundCheck != null)
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out MasterPlatform platform))
        {
            currentPlatform = platform;

            if (platform.isMagnetic)
            {
                isOnMagneticPlatform = true;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out MasterPlatform platform))
        {
            if (platform == currentPlatform)
            {
                currentPlatform = null;
                isOnMagneticPlatform = false;

                if (pendingFlip)
                {
                    ApplyVisualFlip();
                    pendingFlip = false;
                }
            }
        }
    }

    void UpdateAnimatorStates()
    {
        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isJumping", !isGrounded && rb.velocity.y > 0.1f);
        anim.SetBool("isFalling", !isGrounded && rb.velocity.y < -0.1f);
    }

    public void TakeDamage(int amount)
    {
        if (IsInvincible() || isDead) return;

        currentHealth -= amount;
        TriggerHurtFeedback();

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }

    void Die()
    {
        isDead = true;

        // NOTE: Remove auto-respawn here
        // Wait for UI "Respawn" button to call SaveManager.instance.RespawnPlayer();
        //UIManager.instance.ShowDeathScreen(); // Example: trigger popup (if you have it)
    }

    public void Respawn()
    {
        anim.enabled = true;
        col.enabled = true;
        isDead = false;
        rb.velocity = Vector2.zero;
        rb.isKinematic = false;
        DeathHandler deathHandler = GetComponent<DeathHandler>();
        deathHandler.currentHearts = deathHandler.maxHearts;
        deathHandler.UpdateHeartUI();
        isInvincible=false;
        RestoreToFullHealth();
        ResetGravityState();
    }

    public void RestoreToFullHealth()
    {
        currentHealth = maxHealth;
    }

    public void ResetGravityState()
    {
        isFlipped = false;
        GameManager.instance.SetGravityFlipped(false);
        rb.gravityScale = gravityScale;
        transform.localScale = new Vector3(
            lastDirectionFaced * Mathf.Abs(originalScale.x),
            Mathf.Abs(originalScale.y),
            originalScale.z
        );
    }

    public void TriggerHurtFeedback()
    {
        if (isInvincible || isAbilityInvincible)
            return;

        AudioManager.instance.PlayHurt();
        StartCoroutine(BlinkAndInvincible());
    }

    IEnumerator BlinkAndInvincible()
    {
        isInvincible = true;
        float elapsed = 0f;

        while (elapsed < invincibilityDuration)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            yield return new WaitForSeconds(blinkDuration);
            elapsed += blinkDuration;
        }

        spriteRenderer.enabled = true;
        isInvincible = false;
    }

    public bool IsInvincible()
    {
        return isInvincible || isAbilityInvincible;
    }

    public void SetExternalInvincibility(bool state)
    {
        isAbilityInvincible = state;
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
        }
    }
}
