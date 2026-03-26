using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileMove : MonoBehaviour
{
    public float speed;
    public int _damage = 15;

    [SerializeField]private GameObject hitParticlesSystem;
    [SerializeField]public Transform _playerTransform;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (speed != 0f)
        {
            Vector3 direction = _playerTransform.position - transform.position;
            transform.rotation=Quaternion.LookRotation(direction);
            transform.position += transform.forward * (speed * Time.deltaTime);
        }
        else
        {
            Debug.Log("No Speed");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(hitParticlesSystem,transform.position,Quaternion.identity);
            Debug.Log("Hit");
            Destroy(gameObject);
        }
        if (collision.gameObject.tag != "Player")
        {
            Instantiate(hitParticlesSystem,transform.position,Quaternion.identity);
            speed = 0f;

            Destroy(gameObject);
        }
    }
}
