using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Turning Variables
    public float turnSpeed;
    private float horizontalInput;

    //Thrust Variables
    public float thrustForce;
    private float verticalInput;
    private Rigidbody rb;

    //Shooting Variables
    public GameObject bullet;
    public GameObject bulletSpawn;

    //GameManager
    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {

        //Rotation
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.back, turnSpeed * Time.deltaTime * horizontalInput);

        //Shoot
        if(Input.GetButtonDown("Fire1"))
        {
            //Debug.Log("Fire1 was pressed");
            Instantiate(bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
        }


    }

    private void FixedUpdate()
    {
        //Thrust
        verticalInput = Input.GetAxis("Vertical");
        if (verticalInput > 0)
        {
            rb.AddRelativeForce(Vector3.up * thrustForce * verticalInput);
        }
    }
}
