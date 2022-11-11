using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//always getting navmshagent
[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
    //Variable for current target transform
    Transform target;
    //reference to mesh where ai follows for pathfinding
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        //initiliazing agent NavMeshAgent
        agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        if (target != null)
        {
            agent.SetDestination(target.position);
            FaceTarget();
        }
    }

    // move to player to the point
    public void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point);
    }
    //tracking target
    public void FollowTarget(Interactable newTarget)
    {
        //setting the stop position for the player
        agent.stoppingDistance = newTarget.radius * 0.8f;
        //to manuelly control agents rotation
        agent.updateRotation = false;
        //initialize target transform
        target = newTarget.interactionTransform;
    }

    //stop tracking the target
    public void StopFollowingTarget()
    {
        agent.stoppingDistance = 0f;
        agent.updateRotation = true;
        target = null;
    }
    //agent rotation function
    void FaceTarget()
    {
        //initializing the direction of the target position acc to player position
        Vector3 direction = (target.position - transform.position).normalized;
        //how we should rotate to face the target.
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        //smoothly rotate player
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

}
