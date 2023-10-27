using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUIMenu : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Start(){
        if(PlayerPrefs.HasKey("HighestScore")){
            scoreText.text = "HIGHEST SCORE: " + PlayerPrefs.GetInt("HighestScore").ToString("0000");
        }else{
            scoreText.text = "NO SCORE";
        }
    }
}
