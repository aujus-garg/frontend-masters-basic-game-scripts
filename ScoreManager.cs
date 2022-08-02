using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [HideInInspector] public float startTime;
    private float score;
    private float highscore;
    public TMP_Text scoreText;
    public TMP_Text highscoreText;

    void Start()
    {
        // Record time at start of game for score
        startTime = Time.time;

        // Fetch saved highscore
        highscore = PlayerPrefs.GetFloat("Highscore", 0);
    }

    void Update()
    {
        // Find current score based on game start time
        score = Time.time - startTime;

        // Change highscore if score becomes larger
        if (score > highscore) {
            highscore = score;
            PlayerPrefs.SetFloat("Highscore", score);
        }

        // Display scores in UI
        scoreText.text = "Current Score: " + Mathf.Round(score);
        highscoreText.text = "Highscore: " + Mathf.Round(highscore);
    }
}
