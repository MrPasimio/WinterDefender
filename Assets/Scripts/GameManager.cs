using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreDisplay;

    //ScreenLimits
    [Header("Screen Limits")]
    public float horizontalLimit;
    public float verticalLimit;
    public float offset;
    public float safetyRadius;

    [Header("Lives")]
    public int maxLives;
    private int lives;
    public float launchForce;
    public TextMeshProUGUI livesDisplay;
    public GameObject gameOverDisplay;
    public Vector3 spawnPoint = Vector3.zero;
    public GameObject playerPrefab;


    // Start is called before the first frame update
    void Start()
    {
        //Initialize
        score = 0;
        UpdateScore();
        lives = maxLives;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore()
    {
        scoreDisplay.text = $"Score: {score}";
    }

    public void UpdateLives()
    {
        livesDisplay.text = $"Lives: {lives}";
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScore();
    }

    public void LoseLife()
    {
        lives--;
        UpdateLives();
    }

    IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(1);

        //Check to see if spawn is clear

        GameObject[] snowflakes = GameObject.FindGameObjectsWithTag("Snowflake");

        bool canSpawn = false;

        while(!canSpawn)
        {
            canSpawn = true;
            foreach(GameObject snowflake in snowflakes)
            {
                if((snowflake.transform.position - spawnPoint).magnitude < safetyRadius)
                {
                    snowflake.GetComponent<Rigidbody>().AddForce((snowflake.transform.position - spawnPoint).normalized * launchForce, ForceMode.Impulse);
                    canSpawn = false;
                }
            }
            yield return new WaitForSeconds(0.25f);
        }

        Instantiate(playerPrefab, spawnPoint, playerPrefab.transform.rotation);

        

    }

    public void GameOver()
    {
        gameOverDisplay.SetActive(true);
    }

    public void PlayerDie()
    {
        LoseLife();
        if (lives < 0)
        {
            GameOver();
        }
        else
        {
            StartCoroutine(RespawnPlayer());
        }
    }
}
