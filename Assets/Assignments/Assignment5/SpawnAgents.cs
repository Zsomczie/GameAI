using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAgents : MonoBehaviour
{
    [SerializeField] GameObject Agent;
    // Start is called before the first frame update
    void Awake()
    {
        Spawn();
        InvokeRepeating(nameof(Spawn), 10f, 10f);
    }

    // Update is called once per frame
    void Spawn()
    {
        Instantiate(Agent, transform.position,Quaternion.identity);
    }
}
