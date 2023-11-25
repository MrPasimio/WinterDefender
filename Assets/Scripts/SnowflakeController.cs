using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowflakeController : MonoBehaviour
{
    public int pointValue;
    public GameManager gm;

    //Splitting Variables
    public GameObject smallerSnowflake;
    public int smallerSnowflakesToSpawn;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
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
}
