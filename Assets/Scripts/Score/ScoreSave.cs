using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSave : MonoBehaviour
{
    public int scorePoints;
    public static ScoreSave scoreSaveInstance;

    void Awake(){
        DontDestroyOnLoad(this);

        if(scoreSaveInstance != null && scoreSaveInstance != this){
            Destroy(this.gameObject);
        }else{
            scoreSaveInstance = this;
        }
    }

    public void SaveScore(){
        if(!PlayerPrefs.HasKey("HighestScore")){
            PlayerPrefs.SetInt("HighestScore", scorePoints);
        }

        if(PlayerPrefs.HasKey("HighestScore") && scorePoints > PlayerPrefs.GetInt("HighestScore")){
            PlayerPrefs.SetInt("HighestScore", scorePoints);
        }

        PlayerPrefs.Save();
    }

    public int LoadScore(){
        return PlayerPrefs.GetInt("HighestScore");
    }
}
