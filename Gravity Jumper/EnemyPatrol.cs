using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 2f;
    private int moveDirection = 1;

    [Header("Detection")]
    public Transform groundCheck;
    public Transform wallCheck;
    public float checkDistance = 0.2f;
    public LayerMask groundLayer;

    [Header("Visual Feedback")]
    public SpriteRenderer spriteRenderer;
    public float blinkDuration = 0.05f;       // faster blink
    public int blinkCount = 3;
    public Color hitColor = Color.red;
    public Color blinkColor = Color.white;
    private Color originalColor;

    private Rigidbody2D rb;
    private Collider2D col;
    private Animator anim;

    private bool isDead = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = spriteRenderer ?? GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    void FixedUpdate()
    {
        if (!isDead)
            Patrol();
    }

    void Patrol()
    {
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);

        bool noGroundAhead = !Physics2D.Raycast(groundCheck.position, Vector2.down, checkDistance, groundLayer);
        bool wallInFront = Physics2D.Raycast(wallCheck.position, Vector2.right * moveDirection, checkDistance, groundLayer);

        if (noGroundAhead || wallInFront)
            Flip();

        if (anim != null)
            anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
    }

    void Flip()
    {
        moveDirection *= -1;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public void TakeDamage()
    {
        if (isDead) return;

        isDead = true;

        rb.velocity = Vector2.zero;
        if (col != null) col.enabled = false;
        if (anim != null) anim.enabled = false;

        StartCoroutine(DieSequence());
    }

    private System.Collections.IEnumerator DieSequence()
    {
        // Instant red flash
        spriteRenderer.color = hitColor;

        // Wait a single frame
        yield return null;

        // Fast blink sequence
        for (int i = 0; i < blinkCount; i++)
        {
            spriteRenderer.color = blinkColor;
            yield return new WaitForSeconds(blinkDuration);
            spriteRenderer.color = originalColor;
            yield return new WaitForSeconds(blinkDuration);
        }
        AudioManager.instance.PlayEnemyDie();
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(groundCheck.position, groundCheck.position + Vector3.down * checkDistance);
        }

        if (wallCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(wallCheck.position, wallCheck.position + Vector3.right * moveDirection * checkDistance);
        }
    }
}
