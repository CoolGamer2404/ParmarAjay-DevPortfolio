using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public Vector2 direction;
    public GameObject hitEffectPrefab;
    public float lifeTime = 5f; // <-- bullet auto-destroy after 5 seconds

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = direction.normalized * speed;

        // Rotate bullet to face direction
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // Auto-destroy bullet after a delay to avoid memory leaks
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Spawn hit effect
        if (hitEffectPrefab != null)
        {
            AudioManager.instance.PlayBulletHit();
            GameObject hitFX = Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);

            if (hitFX.TryGetComponent(out SelfDestroy selfDestroy))
                selfDestroy.SelfDestroyNow();
            else
                Destroy(hitFX, 1.5f);
        }

        // Try get enemy component from parent safely
        EnemyPatrol enemy = null;

        if (collision.transform.parent != null)
            enemy = collision.transform.parent.GetComponent<EnemyPatrol>();

        // (Optional) fallback if the EnemyPatrol is on the same object
        if (enemy == null)
            enemy = collision.GetComponent<EnemyPatrol>();

        if (enemy == null)
        {
            if (collision.TryGetComponent(out BossController boss))
            {
                boss.TakeDamage(1);
            }
        }
        else
        {
            enemy.TakeDamage();
        }

        Destroy(gameObject); // destroy bullet on impact
    }
}
