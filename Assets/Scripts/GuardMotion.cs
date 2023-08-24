using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GuardMotion : MonoBehaviour
{
    private Animator animator;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit))
        {
            // THIS is the chest. So we want to check if the hit object is the chest
            if ((hit.transform.gameObject == this.gameObject || hit.transform.gameObject == target.gameObject)
                 && hit.distance < 20)
            {
                animator.SetInteger("Status", 1);
            }

        }
    }


    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        animator.SetInteger("Status", 1);
        yield return new WaitForSeconds(1);
        animator.SetInteger("Status", 2);        
    }
    private void OnTriggerExit(Collider other)
    {
        StartCoroutine(waiter2());
    }

    IEnumerator waiter2()
    {
        animator.SetInteger("Status", 3);
        yield return new WaitForSeconds(1);
        animator.SetInteger("Status", 0);
    }
}
