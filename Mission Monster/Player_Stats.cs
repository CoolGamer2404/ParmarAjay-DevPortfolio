using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.UI;

public class Player_Stats : MonoBehaviour
{
    public int Health=7;
    public float Mana=100f;
    [SerializeField]private float ManaRegen=2f;
    [SerializeField]private StarterAssetsInputs starterAssetsInputs;
    [SerializeField]private FirstPersonController firstPersonController;
    [SerializeField]private float cd=.2f;
    [SerializeField]private bool isoncd=false;
    [SerializeField]private Image manaBar;
    [SerializeField]private GameObject _Projectile;
    [SerializeField]private Transform _ProjectileShotPos;
    [SerializeField]private float _ProjectileSpeed=600;
    [SerializeField]private Transform _LookRot;
    [SerializeField]private Ritual_zombieSpawner _ZombieSpawner;
    [SerializeField]private GameObject[] _hearts;
    [SerializeField]private GameObject LosePanel;

    void Start()
    {
        UpdateHealth();
    }

    // Update is called once per frame
    void Update()
    {
        if(starterAssetsInputs.shoot && _ZombieSpawner.isRitualOn){
            if(!isoncd){
                Shoot();

                isoncd=true;
                Invoke(nameof(ResetCD),cd);
            }
        }
        if(Mana<100){
            Mana+=ManaRegen*Time.deltaTime;
            manaBar.fillAmount = Mana / 100;
        }
        if(Mana>100){
            Mana=100;
        }
        if(Health<=0){
            LosePanel.SetActive(true);
            starterAssetsInputs.cursorLocked=false;
        starterAssetsInputs.cursorInputForLook=false;
        firstPersonController.enabled=false;
        Cursor.lockState =  CursorLockMode.None;
        }
    }
    public void UpdateHealth(){
        for(int i=0;i<7;i++){
            _hearts[i].SetActive(false);
        }
        for (int i = 0; i < Health; i++)
        {
            _hearts[i].SetActive(true);
        }
    }
    GameObject projectile;
    Vector3 direction;
    void Shoot(){
        if(Mana>=25f)
        {
            Mana-=25f;
            direction=_LookRot.forward;
            projectile=Instantiate(_Projectile,_ProjectileShotPos.position,Quaternion.LookRotation(direction));
            projectile.GetComponent<Projectile>()._LookRot=_LookRot;
            projectile.GetComponent<Projectile>().ritual_ZombieSpawner=_ZombieSpawner;
            //projectile.GetComponent<Rigidbody>().AddForce(_ProjectileShotPos.forward*_ProjectileSpeed);
        }
    }
    void ResetCD(){
        isoncd=false;
    }
}
