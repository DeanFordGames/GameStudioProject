using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VictoryMenuScore : MonoBehaviour
{
    private ScoreSystem points;

    [SerializeField]
    private TextMeshProUGUI text;

    private void Start()
    {
        points = GameObject.Find("Score").GetComponent<ScoreSystem>();
        text.text = "" + points.getScore();
    }
}
