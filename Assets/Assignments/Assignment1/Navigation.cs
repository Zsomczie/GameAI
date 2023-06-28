using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum State 
{
    Idle,
    Walking,
    PickingUp,
}
public class Navigation : MonoBehaviour
{
    [SerializeField] public NavMeshAgent agent;
    [SerializeField] Transform target;
    [SerializeField] Animator animator;
    bool pickupInProgress = false;
    public State state;
    // Start is called before the first frame update
    private void Awake()
    {
        agent=GetComponent<NavMeshAgent>();
        //animator = GetComponent<Animator>();
    }
    void Start()
    {
        agent.SetDestination(new Vector3(target.position.x, target.position.y, target.position.z+0.7f));
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (agent.hasPath&& state != State.Walking)
        {
            //animator.SetBool("Moving", true);
            //animator.SetBool("PickUp", false);
            state = State.Walking;
        }
        else if (!agent.hasPath && state != State.Idle)
        {
            //animator.SetBool("Moving", false);
            //animator.SetBool("PickUp", true);
            //animator.SetBool("Idle", true);
            state = State.PickingUp;
        }
        if (state==State.Walking)
        {
            animator.SetBool("Moving", true);
        }
        if (state==State.PickingUp && !pickupInProgress)
        {
            animator.SetBool("PickUp", true);
            animator.SetBool("Moving", false);
            StartCoroutine(Pickup());
        }
        if (state == State.Idle) 
        {
            animator.SetBool("Idle", true);
            animator.SetBool("Moving", false);
        }
            IEnumerator Pickup()
        {
            pickupInProgress = true;
            yield return new WaitForSeconds(1.967f);
            Destroy(target.gameObject);

            animator.SetBool("PickUp", false);
            state = State.Idle;
        }
    }
}
