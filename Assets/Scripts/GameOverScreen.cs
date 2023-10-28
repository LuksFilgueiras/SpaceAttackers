using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private PlayerManager playerManager; // só pra pegar a lista de player
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI replayText;
    [SerializeField] private Color32 inactiveColor;

    [SerializeField] private float timeToEnter = 1f;

    void Awake(){
        replayText.color = inactiveColor;
        playerManager = FindObjectOfType<PlayerManager>();
        panel.SetActive(false);
    }


    void Update(){
        int index = 0;
        foreach(Player p in playerManager.playersInGame){
            if(!p.gameObject.activeSelf){
                index++;
            }
        }

        if(index == playerManager.playersInGame.Count){
            Time.timeScale = 0;
            panel.SetActive(true);
        }

        if(panel.activeSelf){
            ScoreSave score = FindObjectOfType<ScoreSave>();
            score.SaveScore();

            timeToEnter -= Time.unscaledDeltaTime;

            if(timeToEnter <= 0){
                replayText.color = Color.white;
            }

            if((Input.GetKeyDown(KeyCode.Space) || Input.GetButton("Fire1")) && timeToEnter <= 0){
                Time.timeScale = 1f;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
