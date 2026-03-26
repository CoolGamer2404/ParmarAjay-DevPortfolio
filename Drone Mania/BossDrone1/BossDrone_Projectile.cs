using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEditor;
using UnityEngine;

public class BossDrone_Projectile : MonoBehaviour
{
    public bool isMultiplayer = false;
    public int _projectileDMG;
    public AttackPointIndicatorHandler attackPointIndicatorHandler;

    public bool _startMovement = false;
    public GameObject target;

    [SerializeField]
    private float _speed;

    [SerializeField]
    private GameObject hitParticlesSystem;

    [SerializeField]
    private GameObject _projectileMeshObj;
    private bool hit = false;

    [SerializeField]
    private Rigidbody rb;

    [SerializeField]private Transform _particleSpawnPoint;
    [Tooltip("Assign Time Of Blast Particle System So This Destroy Target After Particles Play")]
    [SerializeField]private float _ParticlesPlayTime;

    // Update is called once per frame
    Vector3 direction;
    Quaternion lookRotation;

    public void UpdateRotation()
    {
        //direction = (target.transform.position - transform.position).normalized;
        //lookRotation = Quaternion.LookRotation(direction);
        //transform.rotation = lookRotation;
        transform.LookAt(target.transform);
    }

    void FixedUpdate()
    {
        if (!_startMovement)
            return;

        if (!hit)
        {
            direction = (target.transform.position - transform.position).normalized;
            //UpdateRotation();
            transform.position += direction * _speed * Time.deltaTime;
            //transform.LookAt(target.transform);
            rb.AddForce(direction * _speed, ForceMode.Acceleration);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag != "ArenaBoarder")
        {
            StartCoroutine(GotHit());
            transform.GetComponent<BoxCollider>().enabled = false;
            hit = true;
        }
    }

    private IEnumerator GotHit()
    {
        _projectileMeshObj.SetActive(false);
        if (isMultiplayer)
        {
            PhotonNetwork.Instantiate(
                hitParticlesSystem.name,
                _particleSpawnPoint.position,
                Quaternion.identity
            );
        }
        else if (!isMultiplayer)
        {
            Instantiate(hitParticlesSystem, _particleSpawnPoint.position, Quaternion.identity);
        }
        yield return new WaitForSeconds(_ParticlesPlayTime);
        attackPointIndicatorHandler.Destroy();
        SelfDestroy();
    }

    private void SelfDestroy()
    {
        Destroy(this.gameObject);
    }
}
