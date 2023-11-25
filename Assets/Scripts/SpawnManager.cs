using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameManager gm;
    public float horizontalRange;
    public float verticalRange;
    public GameObject player;

    public GameObject snowflake;
    public int snowflakesToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.Find("Player");
        horizontalRange = gm.horizontalLimit;
        verticalRange = gm.verticalLimit;
    }

    // Update is called once per frame
    void Update()
    {
       if(GameObject.FindGameObjectsWithTag("Snowflake").Length <= 0)
        {
            SpawnWave(snowflakesToSpawn);
        }
    }

    public Vector3 GenerateRandomPosition()
    {
        float randomX = Random.Range(-horizontalRange, horizontalRange);
        float randomY = Random.Range(-verticalRange, verticalRange);
        Vector3 randomPos = new Vector3(randomX, randomY, 0);

        while((randomPos - player.transform.position).magnitude < gm.safetyRadius)
        {
             randomX = Random.Range(-horizontalRange, horizontalRange);
             randomY = Random.Range(-verticalRange, verticalRange);
             randomPos = new Vector3(randomX, randomY, 0);
        }

        return randomPos;

    }

    public void SpawnWave(int snowflakes)
    {
        for(int i = 0; i < snowflakes; i++)
        {
            Instantiate(snowflake, GenerateRandomPosition(), transform.rotation); 
        }
    }
}
