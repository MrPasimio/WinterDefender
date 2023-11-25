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


    // Start is called before the first frame update
    void Start()
    {
        //Initialize
        score = 0;
        UpdateScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore()
    {
        scoreDisplay.text = $"Score: {score}";
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScore();
    }
}
