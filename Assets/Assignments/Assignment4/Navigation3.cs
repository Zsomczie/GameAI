using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Navigation3 : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] List<Transform> targets = new List<Transform>();
    [SerializeField] Transform currentTarget;
    [SerializeField] Animator animator;
    [SerializeField] int targetnumber = 0;
    bool pickupInProgress = false;
    public State state;
    // Start is called before the first frame update
    void Start()
    {
        agent.SetDestination(targets[targetnumber].position);
        currentTarget = targets[targetnumber];
    }

    // Update is called once per frame
    void Update()
    {
        if (!agent.hasPath && state != State.Idle)
        {
            if (targetnumber <= targets.Count - 1)
            {
                state = State.PickingUp;
            }

        }
        else if (agent.hasPath && state != State.Walking && !pickupInProgress)
        {
            state = State.Walking;
        }


        if (state == State.Walking)
        {
            animator.SetBool("Moving", true);
            animator.SetBool("Idle", false);
        }
        if (state == State.PickingUp && !pickupInProgress)
        {
            if (currentTarget.gameObject.name.Contains("Collectable"))
            {
                animator.SetBool("PickUp", true);
                animator.SetBool("Moving", false);
                StartCoroutine(Pickup2());
            }
            else
            {
                if (targetnumber < targets.Count - 1)
                {
                    targetnumber++;
                    agent.SetDestination(targets[targetnumber].position);
                    currentTarget = targets[targetnumber];
                }
                else
                {
                    state = State.Idle;
                }
            }
            
        }
        if (state == State.Idle)
        {
            animator.SetBool("Idle", true);
            animator.SetBool("Moving", false);
        }
        IEnumerator Pickup2()
        {
            pickupInProgress = true;
            animator.SetBool("Moving", false);
            yield return new WaitForSeconds(1.967f);
            animator.SetBool("PickUp", false);
            if (currentTarget.gameObject.name.Contains("Collectable"))
            {
                DestroyImmediate(currentTarget.gameObject);

            }
            if (targetnumber < targets.Count - 1)
            {
                targetnumber++;
                agent.SetDestination(targets[targetnumber].position);
                currentTarget = targets[targetnumber];
            }
            else
            {
                state = State.Idle;
            }

            pickupInProgress = false;


        }
    }
}
