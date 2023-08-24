using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestMotion : MonoBehaviour
{
    private Animator animator;
    public GameObject chest;
    public Text chestText;
    public GameObject coins;
    private bool chestClosed = true;

    // Start is called before the first frame update
    void Start()
    {
        chestText.gameObject.SetActive(false);
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (chestText.IsActive())
        {
            StartCoroutine(ChestOpenClose());
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        chestText.gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        chestText.gameObject.SetActive(false);
    }


    public bool isOpen()
    {
        return !chestClosed;
    }

    IEnumerator ChestOpenClose()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetBool("Open", chestClosed);
            coins.SetActive(true);
            chestClosed = !chestClosed;
        }
        

        yield return new WaitForSeconds(2);

        if (chestClosed)
            chestText.text = "Press [E] to OPEN";
        else
            chestText.text = "Press [E] to CLOSE";

    }
}
