using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class SpawnProjectile : MonoBehaviour
{
    public GameObject spawnPoint;
    public List<GameObject> vfx = new List<GameObject>();

    public Quaternion rotation;

    private GameObject effectToSpawn;

    public UIhandler uIhandler;
    public float bulletEnergyUse;

    public Transform crosshair;
    public Image _crossHairImage;

    public Sprite redCrossHairFocus;
    public Sprite blackCrossHairFocus;
    [SerializeField] public DroneStatsScriptableObject drone;
    public Transform player;
    private float lastShootTime = 0;
    public Camera camera;

    void Awake()
    {
        //player = GameObject.FindGameObjectWithTag("Player").transform;
        //drone = player.GetComponent<DroneHandler>().droneStatsScriptableObject;
        //uIhandler = GameObject.FindGameObjectWithTag("PlayerUI").transform.GetComponent<UIhandler>();

        crosshair = uIhandler.crosshair;
        _crossHairImage = uIhandler._crossHairImage;
        redCrossHairFocus = uIhandler.redCrossHairFocus;
        blackCrossHairFocus = uIhandler.blackCrossHairFocus;
    }
    void Start()
    {
        effectToSpawn = vfx[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (uIhandler.isFirePressed)
        {
            SpawnBullet();
        }
        Ray ray = camera.ScreenPointToRay(crosshair.position);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                _crossHairImage.sprite = redCrossHairFocus;
            }
            else
            {
                _crossHairImage.sprite = blackCrossHairFocus;
            }
        }

    }

    private void SpawnBullet()
    {
        if (drone.currentEnergy < drone.baseEnergyCost)
        {
            Debug.Log("low energy");
        }
        if (drone.currentEnergy >= drone.baseEnergyCost)
        {
            GameObject vfx;

            Ray ray = camera.ScreenPointToRay(crosshair.position);
            RaycastHit hit;

            //Vector3 direction = hit.point - transform.position;
            vfx = PhotonNetwork.Instantiate(effectToSpawn.name, spawnPoint.transform.position, Quaternion.identity);
            vfx.transform.rotation = transform.rotation;
            vfx.transform.GetComponent<ProjectileMove>().droneData = drone;
            drone.currentEnergy -= bulletEnergyUse;
            lastShootTime = Time.time;

            /*if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Vector3 direction = hit.point - transform.position;
                vfx = PhotonNetwork.Instantiate(effectToSpawn.name, spawnPoint.transform.position, Quaternion.identity);
                vfx.transform.rotation = Quaternion.LookRotation(direction);
                vfx.transform.GetComponent<ProjectileMove>().droneData = drone;
                drone.currentEnergy -= bulletEnergyUse;
                lastShootTime = Time.time;
            }
            else
            {
                Vector3 direction = hit.point - transform.position;
                vfx = PhotonNetwork.Instantiate(effectToSpawn.name, spawnPoint.transform.position, Quaternion.identity);
                vfx.transform.rotation = transform.rotation;
                vfx.transform.GetComponent<ProjectileMove>().droneData = drone;
                drone.currentEnergy -= bulletEnergyUse;
                lastShootTime = Time.time;
            }*/


            #region OLD
            /*Ray ray = camera.ScreenPointToRay(crosshair.position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.CompareTag("Enemy") || hit.collider.CompareTag("Portal") || hit.collider.CompareTag("Player"))
                {
                    if (spawnPoint != null)
                    {
                        if (Time.time > lastShootTime + drone.currentFireRate)
                        {
                            if (!uIhandler.isMultiPlayer)
                            {
                                Debug.Log("4");
                                Vector3 direction = hit.point - transform.position;
                                vfx = Instantiate(effectToSpawn, spawnPoint.transform.position, Quaternion.LookRotation(direction  ));
                                vfx.transform.rotation = Quaternion.LookRotation(direction);
                                vfx.transform.GetComponent<ProjectileMove>().droneData = drone;
                                drone.currentEnergy -= bulletEnergyUse;
                                lastShootTime = Time.time;
                            }
                            else if (uIhandler.isMultiPlayer)
                            {
                                Debug.Log("3");
                                Vector3 direction = hit.point - transform.position;
                                vfx = PhotonNetwork.Instantiate(effectToSpawn.name, spawnPoint.transform.position, Quaternion.LookRotation(direction));
                                vfx.transform.rotation = Quaternion.LookRotation(direction);
                                vfx.transform.GetComponent<ProjectileMove>().droneData = drone;
                                drone.currentEnergy -= bulletEnergyUse;
                                lastShootTime = Time.time;
                            }
                        }
                    }
                    else
                    {
                        Debug.Log("No Shoot point Found");
                    }
                }

                else if (!hit.collider.CompareTag("Enemy") && !hit.collider.CompareTag("Portal"))
                {
                    if (spawnPoint != null)
                    {
                        if (Time.time > lastShootTime + drone.currentFireRate)
                        {
                            if (!uIhandler.isMultiPlayer)
                            {
                                Debug.Log("2");
                                Vector3 direction = hit.point - transform.position;
                                vfx = Instantiate(effectToSpawn, spawnPoint.transform.position, Quaternion.identity);
                                vfx.transform.rotation = Quaternion.LookRotation(direction);
                                vfx.transform.GetComponent<ProjectileMove>().droneData = drone;
                                drone.currentEnergy -= bulletEnergyUse;
                                lastShootTime = Time.time;
                            }
                            else if (uIhandler.isMultiPlayer)
                            {
                                Debug.Log("1");
                                Vector3 direction = hit.point - transform.position;
                                vfx = PhotonNetwork.Instantiate(effectToSpawn.name, spawnPoint.transform.position, Quaternion.identity);
                                vfx.transform.rotation = Quaternion.LookRotation(direction);
                                vfx.transform.GetComponent<ProjectileMove>().droneData = drone;
                                drone.currentEnergy -= bulletEnergyUse;
                                lastShootTime = Time.time;
                            }
                        }
                    }
                    else
                    {
                        Debug.Log("No Shoot point Found");
                    }
                }
            }
            else
            {
                if (spawnPoint != null)
                {
                    if (Time.time > lastShootTime + drone.currentFireRate)
                    {
                        if (!uIhandler.isMultiPlayer)
                        {
                            Debug.Log("5");
                            Vector3 direction = hit.point - transform.position;
                            vfx = Instantiate(effectToSpawn, spawnPoint.transform.position, Quaternion.identity);
                            vfx.transform.rotation = transform.rotation;
                            vfx.transform.GetComponent<ProjectileMove>().droneData = drone;
                            drone.currentEnergy -= bulletEnergyUse;
                            lastShootTime = Time.time;
                        }
                        else if (uIhandler.isMultiPlayer)
                        {
                            Vector3 direction = hit.point - transform.position;
                            vfx = PhotonNetwork.Instantiate(effectToSpawn.name, spawnPoint.transform.position, Quaternion.identity);
                            vfx.transform.rotation = Quaternion.LookRotation(direction);
                            vfx.transform.GetComponent<ProjectileMove>().droneData = drone;
                            drone.currentEnergy -= bulletEnergyUse;
                            lastShootTime = Time.time;
                        }
                    }
                }
                else
                {
                    Debug.Log("No Shoot point Found");
                }
            }*/
            #endregion

        }

        void OnDrawGizmos()
        {
            // Raycast from the center of the screen
            Ray ray = Camera.main.ScreenPointToRay(crosshair.position);
            RaycastHit hit;

            Gizmos.color = Color.green;
            Gizmos.DrawRay(ray.origin, ray.direction * 100f); // Draw green line

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    Gizmos.color = Color.red;
                    _crossHairImage.sprite = redCrossHairFocus;
                }
                else
                {
                    Gizmos.color = Color.blue;
                    _crossHairImage.sprite = blackCrossHairFocus;
                }
                Gizmos.DrawRay(ray.origin, ray.direction * hit.distance); // Draw line up to the hit point
            }
        }
    }

    [PunRPC]
    void RPC_InstatiateBullet(GameObject bullet, Vector3 pos, Quaternion rot)
    {
        GameObject vfx = PhotonNetwork.Instantiate(bullet.name, pos, rot);
        vfx.transform.rotation = transform.rotation;
        vfx.transform.GetComponent<ProjectileMove>().droneData = drone;
    }
}
