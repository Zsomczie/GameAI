using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationTree : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Animator animator;
    [SerializeField] treeHealth treeHealth;
    bool isCutting = false;
    public int health = 5;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("Tree")!=null)
        {
            agent.SetDestination(GameObject.Find("Tree").transform.position);
            treeHealth = GameObject.Find("Tree").GetComponent<treeHealth>();
        }
        
        animator.SetBool("Moving", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Tree") == null)
        {
            agent.isStopped = true;
            animator.SetBool("Moving", false);
            animator.SetBool("Cutting", false);
            animator.SetBool("Idle", true);
        }
        else if (!agent.hasPath && !isCutting)
        {
            animator.SetBool("Moving", false);
            animator.SetBool("Cutting", true);
            isCutting = true;
            StartCoroutine(damage());
        }
        if (health==0)
        {
            StopAllCoroutines();
            Destroy(gameObject);
        }
        IEnumerator damage() 
        {
            yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
            treeHealth.Health--;
            StartCoroutine(damage());

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("Projectile"))
        {
            health--;
            Destroy(other.gameObject);
        }
    }
}
