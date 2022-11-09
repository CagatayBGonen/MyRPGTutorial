using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//always getting navmshagent
[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        //initiliazing agent NavMeshAgent
        agent = GetComponent<NavMeshAgent>();
    }

    // move to player to the point
    public void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point);
    }
}
