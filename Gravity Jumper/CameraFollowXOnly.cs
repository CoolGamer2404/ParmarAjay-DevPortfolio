using UnityEngine;

public class CameraFollowXOnly : MonoBehaviour
{
    public Transform target;          // Player reference
    public float smoothSpeed = 5f;    // Damping for smooth motion
    public Vector3 offset;            // Optional offset

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 targetPos = new Vector3(
            target.position.x + offset.x,
            target.position.y + offset.y,
            transform.position.z + offset.z
        );

        transform.position = Vector3.Lerp(transform.position, targetPos, smoothSpeed * Time.deltaTime);
    }
}
