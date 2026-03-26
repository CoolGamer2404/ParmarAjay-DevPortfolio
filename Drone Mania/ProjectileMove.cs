using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{

    public float speed;

    private DroneAIStateMachine droneAIStateMachine;
    private Portal1Handler portal1Handler;

    [SerializeField] private GameObject hitParticlesSystem;
    [SerializeField] private bool isMultiplayer = false;
    public DroneStatsScriptableObject droneData;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(enableCollider());
    }

    // Update is called once per frame
    void Update()
    {
        if (speed != 0f)
        {
            transform.position += transform.forward * (speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (isMultiplayer)
        {
            if (collision.gameObject.tag == "Player")
            {
                if (collision.transform.GetComponent<PhotonView>().IsMine)
                    return;
                collision.gameObject.transform.GetComponent<DroneHandler>().ApplyDamage(droneData.baseDamage);
                PhotonNetwork.Instantiate(hitParticlesSystem.name, transform.position, Quaternion.identity);
                Destroy(gameObject);
                PhotonNetwork.Destroy(gameObject);
            }
        }
        else if (!isMultiplayer)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                Instantiate(hitParticlesSystem, transform.position, Quaternion.identity);
                droneAIStateMachine = collision.gameObject.GetComponent<DroneAIStateMachine>();
                droneAIStateMachine.Damage(droneData.baseDamage);
                Destroy(gameObject);
                PhotonNetwork.Destroy(gameObject);
            }
            else if (collision.gameObject.tag == "Portal")
            {
                Instantiate(hitParticlesSystem, transform.position, Quaternion.identity);
                portal1Handler = collision.gameObject.GetComponent<Portal1Handler>();
                portal1Handler.Damage(droneData.baseDamage);
                Destroy(gameObject);
                PhotonNetwork.Destroy(gameObject);
            }
            else if (collision.gameObject.tag != "Enemy" && collision.gameObject.tag != "Portal")
            {
                Instantiate(hitParticlesSystem, transform.position, Quaternion.identity);
                speed = 0f;

                Destroy(gameObject);
                PhotonNetwork.Destroy(gameObject);
            }
        }
    }

    private IEnumerator enableCollider()
    {
        yield return new WaitForSeconds(0.2f);
        this.GetComponent<BoxCollider>().enabled = true;
        StopAllCoroutines();
    }
}
