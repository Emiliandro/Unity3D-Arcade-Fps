using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

    public float attackRange;
    public float attackDamage;
    public float bulletSpeed;

    public float cooldownTime;
    private float nextTimeAttack = 0;

    public GameObject attackGameObject;

    private bool CanAttack(float distance){
        if (distance <= attackRange)
            return true;
        else
            return false;
    }

    public void Awake(){
        if (attackGameObject == null)
            gameObject.SetActive(false);
    }

    public void AttackTarget(Transform target){
        float dir = Vector3.Distance(target.position, transform.position);
        if (!CanAttack(dir))
            return;
        if (Time.time < nextTimeAttack)
            return;
        GameObject bullet = Instantiate(attackGameObject, transform.position, transform.rotation) as GameObject;
        bullet.GetComponent<EnemyBullet>().velocity = bulletSpeed;
        nextTimeAttack = Time.time + cooldownTime;

    }
	
}
