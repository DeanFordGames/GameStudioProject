using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private int points = 10;

    private void OnTriggerEnter(Collider c)
    {
        if(c.gameObject.name == "Player")
        {
            ScoreSystem score = GameObject.Find("Score").GetComponent<ScoreSystem>();
            score.changeScore(points);
            Destroy(gameObject);
        }
    }
}
