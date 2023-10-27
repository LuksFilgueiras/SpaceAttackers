using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI replayText;
    [SerializeField] private Color32 inactiveColor;

    [SerializeField] private float timeToEnter = 1f;

    void Awake(){
        replayText.color = inactiveColor;
        player = FindObjectOfType<Player>();
        panel.SetActive(false);
    }


    void Update(){
        if(player == null){
            panel.SetActive(true);
            Time.timeScale = 0f;
        }

        if(panel.activeSelf){
            timeToEnter -= Time.unscaledDeltaTime;

            if(timeToEnter <= 0){
                replayText.color = Color.white;
            }

            if(Input.GetKeyDown(KeyCode.Space) && timeToEnter <= 0){
                Time.timeScale = 1f;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
