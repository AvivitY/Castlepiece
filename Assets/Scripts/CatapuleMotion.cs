using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatapuleMotion : MonoBehaviour
{
    private Animator animator;
    public Text catText;
    private bool shot=false;

    // Start is called before the first frame update
    void Start()
    {
        catText.gameObject.SetActive(false);
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (catText.IsActive())
        {
            StartCoroutine(CatShot());
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!shot)
        {
            catText.text = "Press [G] to SHOT";
            catText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        catText.gameObject.SetActive(false);
    }




    IEnumerator CatShot()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            animator.SetBool("Shot", true);
            shot = true;
        }


        yield return new WaitForSeconds(2);
        catText.text = "Press [G] to SHOT";

    }
}
