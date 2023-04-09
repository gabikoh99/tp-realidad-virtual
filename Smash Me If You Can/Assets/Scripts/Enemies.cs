using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemies : MonoBehaviour
{
    enum EnemyBehaviourStates
    {
        chasing,
        leavingBallAlone,
    }
    
    private NavMeshAgent navMeshAgent;               //  Nav mesh agent component
    private float speedRun;                       //  Running speed
    private Vector3 ballLastPosition;                       //  Last position of the player

    private EnemyBehaviourStates state;
    private float timeLeavingBallAlone = 3;  // tres segundos
    
    void Start()
    {    
        state = EnemyBehaviourStates.chasing;
        speedRun = 20;
        ballLastPosition = GameObject.Find("Ball").transform.position;
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.isStopped = false;
        navMeshAgent.speed = speedRun;             //  Set the navemesh speed with the normal speed of the enemy
        navMeshAgent.SetDestination(ballLastPosition);    //  Set the destination to the first waypoint
    }
 
    private void Update()
    {
        if(!navMeshAgent.isStopped){
            if (state == EnemyBehaviourStates.chasing)
            {
                var ballObject = GameObject.Find("Ball");
                if(ballObject != null){
                    ballLastPosition = ballObject.transform.position;
                    
                    if (Vector3.Distance(transform.position, ballLastPosition) <= 5) //Esto es el rango, frena un toque cuanto toca la pelota
                    {
                        LeaveBallAloneForAMoment();
                    }
                    else
                    {
                        Chasing();
                    }
                }
            }
            else if(state == EnemyBehaviourStates.leavingBallAlone)
            {
                // Solo estaremos en este estado por un tiempo corto para darle al player oportunidad de recuperarse
                timeLeavingBallAlone -= Time.deltaTime;
                if (timeLeavingBallAlone <= 0)
                {
                    timeLeavingBallAlone = 1;
                    state = EnemyBehaviourStates.chasing;
                }
            }
        }
    }
 
    private void Chasing()
    {
        Move(speedRun);
        navMeshAgent.SetDestination(ballLastPosition);          //  set the destination of the enemy to the player location
    }
    
    void Move(float speed)
    {
        navMeshAgent.speed = speed;
    }

    public void Push(Vector3 direction, float force)
    {
        gameObject.GetComponent<Rigidbody>().AddForce(direction * force, ForceMode.Impulse);
    }
    
    public void Stop()
    {
        navMeshAgent.isStopped = true;
        navMeshAgent.speed = 0;
    }

    public void LeaveBallAloneForAMoment()
    {
        state = EnemyBehaviourStates.leavingBallAlone;
    }
}