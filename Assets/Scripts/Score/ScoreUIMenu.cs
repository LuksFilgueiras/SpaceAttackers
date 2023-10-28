using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUIMenu : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Start(){
        if(PlayerPrefs.HasKey("HighestScore")){
            scoreText.text = "MAX. ENEMIES KILLED: " + PlayerPrefs.GetInt("HighestScore").ToString("00");
        }else{
            scoreText.text = "ZERO ENEMIES KILLED";
        }
    }
}
