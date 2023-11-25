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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        //Rotation
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.back, turnSpeed * Time.deltaTime * horizontalInput);


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
