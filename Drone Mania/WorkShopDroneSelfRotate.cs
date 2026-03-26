using UnityEngine;

public class WorkShopDroneSelfRotate : MonoBehaviour
{
    [SerializeField]private float rotationSpeed = 0;
    void Update()
    {
        this.transform.Rotate(0, Time.deltaTime * rotationSpeed, 0, Space.Self);
    }
}
