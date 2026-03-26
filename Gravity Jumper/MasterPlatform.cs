using UnityEngine;

public class MasterPlatform : MonoBehaviour
{
    public enum PlatformType { Neutral, Blue, Red }
    public PlatformType platformType = PlatformType.Neutral;

    [Header("References")]
    public SpriteRenderer spriteRenderer;
    public Collider2D platformCollider;
    public GameObject magneticField;

    [Header("Visibility & Gravity")]
    public bool isMagnetic = false;
    public bool isSticking = false; // True if player is currently touching

    [Header("Movement")]
    public bool isMoving = false;
    public Transform pointA, pointB;
    public float moveSpeed = 2f;
    private bool movingToB = true;

    // Velocity tracking
    private Vector3 previousPosition;
    public Vector3 platformVelocity { get; private set; }

    private float lastTouchTime = -999f;
    private float touchBuffer = 0.15f;

    void Start()
    {
        if (spriteRenderer == null) spriteRenderer = GetComponent<SpriteRenderer>();
        if (platformCollider == null) platformCollider = GetComponent<Collider2D>();

        previousPosition = transform.position;
    }

    void Update()
    {
        HandleMovement();
        if (platformType != PlatformType.Neutral)
            UpdateVisibility();

        platformVelocity = (transform.position - previousPosition) / Time.fixedDeltaTime;
        previousPosition = transform.position;
    }

    void HandleMovement()
    {
        if (!isMoving || pointA == null || pointB == null) return;

        Vector3 target = movingToB ? pointB.position : pointA.position;
        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.05f)
        {
            movingToB = !movingToB;
        }
    }

    void UpdateVisibility()
    {
        bool flipped = GameManager.instance != null && GameManager.instance.IsGravityFlipped;

        bool visible =
            platformType == PlatformType.Neutral ||
            (platformType == PlatformType.Blue && !flipped) ||
            (platformType == PlatformType.Red && flipped) ||
            (isMagnetic && isSticking) ||
            (Time.time - lastTouchTime < touchBuffer);

        spriteRenderer.enabled = visible;
        platformCollider.enabled = visible;
        if (magneticField != null) magneticField.SetActive(visible);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isMagnetic) return;

        if (collision.gameObject.CompareTag("Player"))
        {
            isSticking = true;
            lastTouchTime = Time.time;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!isMagnetic) return;

        if (collision.gameObject.CompareTag("Player"))
        {
            isSticking = false;
            lastTouchTime = Time.time;
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (pointA != null && pointB != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(pointA.position, pointB.position);
            Gizmos.DrawWireSphere(pointA.position, 0.1f);
            Gizmos.DrawWireSphere(pointB.position, 0.1f);
        }
    }
}
