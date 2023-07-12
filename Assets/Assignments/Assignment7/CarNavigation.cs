using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarNavigation : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] List<Transform> targets = new List<Transform>();
    // Start is called before the first frame update
    void Start()
    {
        agent.SetDestination(targets[0].position);
    }
}
