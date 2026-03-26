using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public enum ObstacleType { Default, Blade, Laser }
    public ObstacleType type = ObstacleType.Default;

    [Header("Gravity Flip Behavior")]
    public bool stopOnGravityFlip = false;
    public bool rotateOnGravityFlip = false;
    public bool isTriggerOnFlipped = true;
    public float rotateAmount = 90f;

    [Header("References")]
    public Collider2D damageCollider;
    public Animator obstacleAnimator;

    [SerializeField] private bool previousGravityState;

    void Start()
    {
        previousGravityState = GameManager.instance.IsGravityFlipped;
        ApplyInitialState();
    }

    void Update()
    {
        bool currentGravity = GameManager.instance.IsGravityFlipped;

        if (currentGravity != previousGravityState)
        {
            OnGravityChanged(currentGravity);
            previousGravityState = currentGravity;
        }
    }

    void OnGravityChanged(bool isFlipped)
    {
        //if (isTriggerOnFlipped && !isFlipped)
        //{
        //    Debug.Log(isFlipped +" : " +isTriggerOnFlipped);
        //    return;
        //}
        if (rotateOnGravityFlip)
        {
            transform.Rotate(0f, 0f, rotateAmount);
        }

        if (stopOnGravityFlip)
        {
            if (isFlipped)
                StopObstacle();
            else
                StartObstacle();
        }
    }

    void ApplyInitialState()
    {
        bool flipped = GameManager.instance.IsGravityFlipped;

        if (stopOnGravityFlip && (flipped && isTriggerOnFlipped))
            StopObstacle();
        else
            StartObstacle();
    }

    public void StopObstacle()
    {
        if (obstacleAnimator != null)
            obstacleAnimator.enabled = false;

        if (damageCollider != null)
            damageCollider.enabled = false;
    }

    public void StartObstacle()
    {
        if (obstacleAnimator != null)
            obstacleAnimator.enabled = true;

        if (damageCollider != null)
            damageCollider.enabled = true;
    }
}
