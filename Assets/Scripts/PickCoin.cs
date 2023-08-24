using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //for Text

public class PickCoin : MonoBehaviour
{
    //public AudioClip pickSound;
    public AudioSource pickSound;
    public Text coinsText;
    static int numOfCoins=0;
    public float rotationSpeed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        this.gameObject.SetActive(false);
        this.pickSound.Play();
        numOfCoins++;
        coinsText.text = "Gold Coins:" + numOfCoins;
        //AudioSource.PlayClipAtPoint(pickSound, transform.position);
    }
}
