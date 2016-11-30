using UnityEngine;
using System.Collections;
using System;

[Serializable]
public enum EnemyStatus
{
    Patrol,
    Attack
}

public class EnemyMove : MonoBehaviour{

    public float speed;

    public Transform[] wayPoints;
    public bool loop = true;
    public float pauseDuration = 0; //How long to pause at a Waypoint

    private CharacterController character;
    private float curTime;
    private int currentWaypoint = 0;
    public float offsetZ = 5f;

    private FieldofView fieldTarget;

    public EnemyStatus statusEnemy = EnemyStatus.Patrol;

    void Start(){
        character = GetComponent<CharacterController>();
        fieldTarget = GetComponent<FieldofView>();
    }

    void Update(){

        if (fieldTarget.visibleTargets.Count > 0)
            statusEnemy = EnemyStatus.Attack;
        else
            statusEnemy = EnemyStatus.Attack;

        switch (statusEnemy){
           
            case EnemyStatus.Patrol:{ 
                    if (currentWaypoint < wayPoints.Length){
                        patrol();
                    }else{
                        if (loop){
                            currentWaypoint = 0;
                        }
                    }
                    break;
                }
            case EnemyStatus.Attack:
                {
                    foreach(var t in fieldTarget.visibleTargets){
                        Attack(t);
                    }
                    break;
                }
        }


    }

    void Attack(Transform target){

        if (Vector3.Distance(target.position, transform.position) < offsetZ)
            return;

        Vector3 targetPosition = target.position;
        targetPosition.y = transform.position.y;
        Vector3 moveDirection = targetPosition - transform.position;
        Debug.Log(Vector3.Distance(target.position, transform.position));
        character.Move(moveDirection.normalized * speed * Time.deltaTime);

    }

    void patrol(){

        Vector3 target = wayPoints[currentWaypoint].position;
        target.y = transform.position.y; // Keep waypoint at character's height
        Vector3 moveDirection = target - transform.position;

        if (moveDirection.magnitude < 0.5f){
            if (curTime == 0)
                curTime = Time.time; // Pause over the Waypoint
            if ((Time.time - curTime) >= pauseDuration){
                currentWaypoint++;
                curTime = 0;
            }
        }else{
            character.Move(moveDirection.normalized * speed * Time.deltaTime);
        }
    }
}

