using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desp : MonoBehaviour
{
    public GameObject desp;
    public GameObject menu, menu2;
    private bool once=false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!once)
        {
            if (!menu.activeSelf && !menu2.activeSelf)
            {
                EnableDesp();
                once = true;
            }
        }
    }

    private void EnableDesp()
    {
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        desp.SetActive(true);
        yield return new WaitForSeconds(3);
        desp.SetActive(false);
    }
}
