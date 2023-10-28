using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private ScoreSave score;
    [SerializeField] private TextMeshProUGUI scoreText;
    void Start()
    {
        score = FindObjectOfType<ScoreSave>();
        score.scorePoints = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.scorePoints.ToString("00");   
    }
}
