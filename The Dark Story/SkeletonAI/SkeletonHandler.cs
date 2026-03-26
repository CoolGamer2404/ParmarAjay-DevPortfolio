using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Audio;

public class SkeletonHandler : MonoBehaviour
{
    public static bool SkeletonHasSpawned;
    public NavMeshAgent skeleton;
    public Transform locationA;
    public Transform locationB;

    public Vector3 warpLocation;

    [SerializeField] private bool playerEntered = false;

    public ParticleSystem smokeParticleSystem;

    public int chooseRandomTargetTimer;
    [SerializeField] private int spawnTimer;
    [SerializeField] private int deSpawnTimer;

    [SerializeField] private Transform spawn;
    [SerializeField] private Transform target;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip intenseSound;
    [SerializeField] private AudioClip deSpawnSound;

    //[SerializeField] private bool hasSpawned;

    void Start()
    {
        playerEntered = false;
        SkeletonHasSpawned = false;
        //hasSpawned=false;
    }
    void Update()
    {
        if (SkeletonHasSpawned)
        {
            audioSource.PlayOneShot(intenseSound);
            //Debug.Log("Audio Source playing: " + audioSource.isPlaying);
            //Debug.Log("Audio Source volume: " + audioSource.volume);
            if (skeleton.remainingDistance < skeleton.stoppingDistance)
            {
                StartCoroutine(DeSpawn());
            }
        }
        else if (!SkeletonHasSpawned)
        {
            audioSource.Stop();
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && playerEntered == false && SkeletonHasSpawned == false)
        {
            StartCoroutine(ChooseRandomTarget());
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && playerEntered == true)
        {
            playerEntered = false;
        }
    }

    public IEnumerator ChooseRandomTarget()
    {
        playerEntered = true;
        if (Random.Range(0, 2) == 0)
        {
            spawn = locationA;
            target = locationB;
        }
        else
        {
            spawn = locationB;
            target = locationA;
        }
        yield return new WaitForSeconds(chooseRandomTargetTimer);
        StartCoroutine(Spawn());
    }

    public IEnumerator Spawn()
    {
        audioSource.PlayOneShot(deSpawnSound);
        PlaySmokeParticleEffect(spawn);
        yield return new WaitForSeconds(spawnTimer);
        skeleton.Warp(spawn.position);
        skeleton.SetDestination(target.position);
        SkeletonHasSpawned = true;
        Debug.Log("Spawned");
    }

    public IEnumerator DeSpawn()
    {
        //hasSpawned=true;
        skeleton.ResetPath();
        skeleton.Warp(warpLocation);
        yield return new WaitForSeconds(deSpawnTimer);
        PlaySmokeParticleEffect(target);
        SkeletonHasSpawned = false;
        spawn = null;
        target = null;
        Debug.Log("DeSpawned");
    }

    private void PlaySmokeParticleEffect(Transform location)
    {
        smokeParticleSystem.transform.position = location.position;
        smokeParticleSystem.Play();
    }
}
