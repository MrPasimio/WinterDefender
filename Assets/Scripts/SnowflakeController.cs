using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowflakeController : MonoBehaviour
{
    public int pointValue;
    public GameManager gm;
    public Rigidbody rb;

    //Splitting Variables
    public GameObject smallerSnowflake;
    public int smallerSnowflakesToSpawn;

    //Random Force Variables
    public float forceRange;
    public float torqueRange;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody>();

        AddRandomForce();
        AddRandomTorque();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            gm.AddScore(pointValue);
            Destroy(collision.gameObject);
            SpawnSmaller(smallerSnowflakesToSpawn);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }

    private void SpawnSmaller(int numberToSpawn)
    {
        if(smallerSnowflake != null)
        {
            for (int i = 0; i < numberToSpawn; i++)
            {
                Instantiate(smallerSnowflake, transform.position, transform.rotation);
            }
        }
    }

    public void AddRandomForce()
    {
        float randomForceX = Random.Range(-forceRange, forceRange);
        float randomForceY = Random.Range(-forceRange, forceRange);
        Vector3 randomForce = new Vector3(randomForceX, randomForceY, 0);

        rb.AddForce(randomForce, ForceMode.Impulse);
    }

    public void AddRandomTorque()
    {
        float randomTorque = Random.Range(-torqueRange, torqueRange);
        rb.AddTorque(Vector3.back * randomTorque, ForceMode.Impulse);
    }
}
