using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent agent; // Reference to the NavMeshAgent
    private Vector3 spawnPos;
    private float waitTime;
    private float StartWaitTime = 5;
    private Animator mAnimator;
    private Vector3 destination;



    FieldOfView pov;

    // Use this for initialization
    void Start()
    {
       // mAnimator = GetComponent<Animator>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        spawnPos = transform.position;
        waitTime = StartWaitTime;

        pov = FieldOfView.instance;

    }

    // Update is called once per frame
    void Update()
    {
        if (pov.canSeePlayer)
        {
            
            // Move towards the target
            FaceTarget();
            destination = pov.playerRef.transform.position;
            agent.SetDestination(destination);
           // mAnimator.SetBool("walking", true);

            waitTime = StartWaitTime;
        }
        else
        {
            //means enemy arrived at last known location
            if (Vector3.Distance(transform.position, destination) < 1f)
            {
            //    mAnimator.SetBool("walking", false);
                waitTime -= Time.deltaTime;
            }
            //time to walk back to my location
            if (waitTime <= 0)
            {
                agent.SetDestination(spawnPos);
            //    mAnimator.SetBool("walking", true);


            }
        }
        //if this passes, it means it went back to its starting location
        if (Vector3.Distance(transform.position, spawnPos) < 2f)
        {
          //  mAnimator.SetBool("walking", false);
            waitTime = StartWaitTime;
        }






    }


    // Rotate to face the target
    void FaceTarget()
    {
        Vector3 direction = (pov.playerRef.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }








}
