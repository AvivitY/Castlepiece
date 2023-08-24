using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotion : MonoBehaviour
{
    private CharacterController controller; // variable definition
    private float speed = 10;
    private float angularSpeed = 100;
    private float rotationAboutY = 0;
    private float rotationAboutX = 0; // degrees
    public GameObject aCamera; // [public] must be connected to external object
    public GameObject fail;
    private AudioSource steps;
    public int maxHealth = 1000;
    public int currentHealth;
    public HealthBar healthBar;
    public GameObject[] enemy;


    // Start is called before the first frame update
    void Start()
    {
        // connect  controller to  corresponding component in player
        controller = GetComponent<CharacterController>();
        steps = GetComponent<AudioSource>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        float dx = 0;
        float dy = -1; // gravity
        float dz = 0;

        // set the rotation angles
        rotationAboutY += Input.GetAxis("Mouse X") * angularSpeed * Time.deltaTime;
        Vector3 rotation = new Vector3(0, rotationAboutY, 0);
        transform.localEulerAngles = rotation; // sets the rotation angles of THIS
        //  set the rotation angles about X axis
        rotationAboutX -= Input.GetAxis("Mouse Y") * angularSpeed * Time.deltaTime;
        if (Mathf.Abs(rotationAboutX) > 60)
        {
            rotationAboutX = 0;
        }
        else
        {
            Vector3 rotation_x = new Vector3(rotationAboutX, 0, 0);
            aCamera.transform.localEulerAngles = rotation_x;
        }
        //       this.transform.position = new Vector3(dx, dy, dz); // simple change of position
        //       this.transform.Translate(0, 0, 0.1f); // another simple change of position

        dx = Input.GetAxis("Horizontal"); // can be -1, 0 ,1 i.e left, none, right
        dx *= speed * Time.deltaTime; // Time.deltaTime is the time lapse between frames
        dz = Input.GetAxis("Vertical");// can be -1, 0 ,1 i.e forward, none, backward
        dz *= speed * Time.deltaTime;
        // add motion using Character Controller
        Vector3 motion = new Vector3(dx, dy, dz); // dx, dy, dz are Local coordinates
        motion = transform.TransformDirection(motion); // transform LOCAL to GLOBAL
        controller.Move(motion); // The vector motion must be in Global coordinates
        if (Mathf.Abs(dz) > 0.01 || Mathf.Abs(dx) > 0.01)
        {
            if (!steps.isPlaying)
                steps.Play();
        }

        RaycastHit hit;

        if (Physics.Raycast(aCamera.transform.position, aCamera.transform.forward, out hit))
        {
            for (int i = 0; i < enemy.Length; i++)
            {
                if (hit.transform.gameObject == enemy[i].transform.gameObject && hit.distance <10 && (enemy[i].GetComponent<Animator>().GetInteger(Animator.StringToHash("Status")) != 3))
                {
                    TakeDamage(1);
                    StartCoroutine(wait());
                }
            }
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth == 0)
        {
            fail.SetActive(true);
        }
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(100);
    }
}
