using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Tarodev;
using UnityEngine;

public class AttackPointIndicatorHandler : MonoBehaviour
{
    public bool isMultiplayer=false;
    public int _projectileDMG;
    [SerializeField]private GameObject _projectilePrefabSinglePlayer;
    [SerializeField]private GameObject _projectilePrefabMultiPlayer;
    [SerializeField]private Transform[] _spawnPositions;
    [SerializeField]private GameObject _target;

    private GameObject self;

    void Start()
    {
        self=this.gameObject;
        SpawnProjectile();
    }

    public void Destroy(){
        if(!isMultiplayer){
            Destroy(self);
        }
        else if(isMultiplayer){
            PhotonNetwork.Destroy(self);
        }
    }
    public void SpawnProjectile(){
        if(!isMultiplayer){
            GameObject projectile = Instantiate(
                _projectilePrefabSinglePlayer,
                _spawnPositions[Random.Range(0,_spawnPositions.Length)].position,
                Quaternion.identity
            );
            projectile.GetComponent<BossDrone_Projectile>()._projectileDMG=_projectileDMG;
            projectile.GetComponent<BossDrone_Projectile>().target=_target;
            projectile.GetComponent<BossDrone_Projectile>().attackPointIndicatorHandler=this.gameObject.GetComponent<AttackPointIndicatorHandler>();

            projectile.GetComponent<BossDrone_Projectile>().UpdateRotation();
            projectile.GetComponent<BossDrone_Projectile>()._startMovement=true;
        }
        else if(isMultiplayer){
            GameObject projectile = PhotonNetwork.Instantiate(
                _projectilePrefabMultiPlayer.name,
                _spawnPositions[Random.Range(0,_spawnPositions.Length)].position,
                Quaternion.identity
            );
            projectile.GetComponent<BossDrone_Projectile>()._projectileDMG=_projectileDMG;
            projectile.GetComponent<BossDrone_Projectile>().target=_target;
            projectile.GetComponent<BossDrone_Projectile>().attackPointIndicatorHandler=this.gameObject.GetComponent<AttackPointIndicatorHandler>();

            projectile.GetComponent<BossDrone_Projectile>().UpdateRotation();
            projectile.GetComponent<BossDrone_Projectile>()._startMovement=true;
        }
    }
}
