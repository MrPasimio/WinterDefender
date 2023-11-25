using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    public GameManager gm;

    public float horizontalLimit;
    public float verticalLimit;
    public float offset;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        horizontalLimit = gm.horizontalLimit;
        verticalLimit = gm.verticalLimit;
        offset = gm.offset;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > horizontalLimit)
        {
            transform.position = new Vector3(-horizontalLimit + offset, transform.position.y, 0);
        }

        if (transform.position.x < -horizontalLimit)
        {
            transform.position = new Vector3(horizontalLimit - offset, transform.position.y, 0);
        }

        if (transform.position.y > verticalLimit)
        {
            transform.position = new Vector3(transform.position.x, -verticalLimit + offset, 0);
        }

        if (transform.position.y < -verticalLimit)
        {
            transform.position = new Vector3(transform.position.x, verticalLimit - offset, 0);
        }
    }
}
