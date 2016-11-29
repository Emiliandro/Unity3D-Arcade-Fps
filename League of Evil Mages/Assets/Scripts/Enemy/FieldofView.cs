﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FieldofView : MonoBehaviour {

    public float viewRadius;
    [Range(0,360)]
    public float viewAngle;

    public LayerMask targetMask;
    public LayerMask obstacleMask;

    public List<Transform> visibleTargets = new List<Transform>();

    public EnemyMove enemyMove;
    public EnemyAttack attackEnemy;

    private void Awake(){
        attackEnemy = GetComponent<EnemyAttack>();
    }

    void Start(){
        StartCoroutine("FindTargetWithDelay", .2f);
    }

    IEnumerator FindTargetWithDelay(float delay){
        while (true){
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
        }
    }

    void FindVisibleTargets(){
        visibleTargets.Clear();
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);
        for(int i = 0; i < targetsInViewRadius.Length; i++){
            Transform target = targetsInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if(Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2){
                float dstToTarget = Vector3.Distance(transform.position, target.position);
                if(!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask)){
                    visibleTargets.Add(target);
                }
            }
        }
    }

    public Vector3 DirFromAngle(float angleInDegree, bool angleIsGlobal) {
        if (!angleIsGlobal){
            angleInDegree += transform.eulerAngles.y;
        }

        return new Vector3(Mathf.Sin(angleInDegree * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegree * Mathf.Deg2Rad));
    }

    public void Update(){

        if (visibleTargets == null)
            return;

        if(visibleTargets.Count > 0){
            foreach(Transform t in visibleTargets){
                attackEnemy.AttackTarget(t);
            }
        }
    }

}
