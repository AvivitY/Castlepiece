using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Shooting : MonoBehaviour
{
    public GameObject aCamera;
    //public GameObject aTarget;
    public GameObject[] enemy;
    private Animator animator;
    public GameObject gun;
    //public GameObject gunMuzzle;
    private AudioSource shootingSound;
    private LineRenderer line;
    private int counter=0;
    public GameObject popup;
    public GameObject coins;
    //public ParticleSystem muzzleFlash;



    // Start is called before the first frame update
    void Start()
    {
        shootingSound = gun.GetComponent<AudioSource>();
        line = gun.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            shootingSound.Play();
            //muzzleFlash.Play();

            if(Physics.Raycast(aCamera.transform.position,aCamera.transform.forward, out hit))
            {
                //aTarget.transform.position = hit.point;
                // draw shooting for a moment
                //StartCoroutine(DrawFlash());
                for (int i = 0; i < enemy.Length; i++)
                {
                    if (hit.transform.gameObject == enemy[i].transform.gameObject)
                    {
                        animator = enemy[i].GetComponent<Animator>();
                        NavMeshAgent agent = enemy[i].GetComponent<NavMeshAgent>();
                        // aTarget.transform.position = hit.point;
                        // stop enemy motion
                        agent.enabled = false;
                        counter++;
                        animator.SetInteger("Status", 3);
                    }
                }
            }
            
        }
        if (counter == enemy.Length && coins.activeSelf)
        {
            StartCoroutine(Delay());
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2);
        popup.SetActive(true);
    }
}
