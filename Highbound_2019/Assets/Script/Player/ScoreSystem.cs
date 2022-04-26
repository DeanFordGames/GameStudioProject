using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    private int score = 0;
    private Text scoreText;

    private void Start()
    {
        scoreText = gameObject.GetComponent<Text>();
        setScore(0);
    }

    public void changeScore(int addScore)
    {
        score += addScore;
        scoreText.text = "Score: " + score;
    }

    public void setScore(int set)
    {
        score = set;
        scoreText.text = "Score: " + score;
    }
}
