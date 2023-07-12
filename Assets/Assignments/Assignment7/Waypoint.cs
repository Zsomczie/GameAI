using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Waypoint : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform waypoint;
    public int laps = 0;
    private void OnTriggerEnter(Collider other)
    {
        agent.SetDestination(waypoint.position);
        laps++;
        if (gameObject.name.Contains("finishLine")&&laps==12)
        {
            agent.isStopped = true;
        }
    }
}
