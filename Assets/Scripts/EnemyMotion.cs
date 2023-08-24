using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMotion : MonoBehaviour
{
    private Animator animator;
    //public GameObject aCamera;
    private NavMeshAgent agent;
    public GameObject target;
    public GameObject menu,menu2;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        //agent.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!menu.activeSelf && !menu2.activeSelf)
        {
            RaycastHit hit;
            agent.SetDestination(target.transform.position);
            //StartCoroutine(waiter());
            if (Physics.Raycast(this.transform.position, this.transform.forward, out hit))
            {
                // THIS is the chest. So we want to check if the hit object is the chest
                if ((hit.transform.gameObject == this.gameObject || hit.transform.gameObject == target.gameObject)
                     && hit.distance < 20)
                {
                    animator.SetInteger("Status", 1);
                    agent.enabled = false;
                }

            }
        }
    }
    IEnumerator waiter()
    {
        yield return new WaitForSeconds(2);
        //animator.SetInteger("Status", 1);
    }
}
