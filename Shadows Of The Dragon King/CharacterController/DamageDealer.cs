using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    bool canDealDamage;
    List<GameObject> hasDealtDamage;

    [SerializeField] float weaponLength;
    [SerializeField] float weaponDamage;
    [SerializeField]private CharacterDataHandler characterDataHandler;
    [SerializeField]private Character Character;
    void Start()
    {
        canDealDamage = false;
        hasDealtDamage = new List<GameObject>();
        characterDataHandler=GameObject.Find("Character").GetComponent<CharacterDataHandler>();
        Character=GameObject.Find("CharacterController").GetComponent<Character>();
    }

    void Update()
    {
        /*if (canDealDamage)
        {
            RaycastHit hit;

            int layerMask = 1 << 9;
            if (Physics.Raycast(transform.position, -transform.up, out hit, weaponLength, layerMask))
            {
                if (hit.transform.TryGetComponent(out Enemy enemy) && !hasDealtDamage.Contains(hit.transform.gameObject))
                {
                    enemy.TakeDamage(characterDataHandler.CountDamage());
                    enemy.HitVFX(hit.point);
                    hasDealtDamage.Add(hit.transform.gameObject);
                }
            }
        }*/
    }
    [SerializeField]CharacterDataHandler dataHandler;
    void OnTriggerEnter(Collider collision){
        if (canDealDamage && !hasDealtDamage.Contains(collision.gameObject) && collision.gameObject.tag=="Enemy"){
            collision.gameObject.GetComponent<Enemy>().TakeDamage(characterDataHandler.CountDamage());
            hasDealtDamage.Add(collision.gameObject);
            Character.playAttack();
        }
    }
    public void StartDealDamage()
    {
        canDealDamage = true;
        hasDealtDamage.Clear();
    }
    public void EndDealDamage()
    {
        canDealDamage = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position - transform.up * weaponLength);
    }
}
