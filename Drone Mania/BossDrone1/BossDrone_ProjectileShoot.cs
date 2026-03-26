using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDrone_ProjectileShoot : MonoBehaviour
{
    [SerializeField]private GameObject _Projectile;
    [SerializeField]private Transform _ProjectileShotPos;
    [SerializeField]private float _ProjectileSpeed=600;
    // Start is called before the first frame update
    void Start()
    {
        _ProjectileShotPos=this.gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    GameObject projectile;
    Vector3 direction;
    public void Shoot(){
        direction=_ProjectileShotPos.TransformDirection(Vector3.forward);
        projectile=Instantiate(_Projectile,_ProjectileShotPos.position,Quaternion.LookRotation(direction));
        projectile.GetComponent<BossDrone_Projectile_Move>()._LookRot=_ProjectileShotPos;
        return;
    }
}
