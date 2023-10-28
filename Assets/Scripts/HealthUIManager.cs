using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HealthUIManager : MonoBehaviour
{

    public List<Player> playersInGame = new List<Player>();

    public PlayerHealthUI[] playersHealthUI = new PlayerHealthUI[2];

    public PlayerInputManager playerInputManager;

    public void AddPlayersInGame(Player player){
        playersInGame.Add(player);

        if(playersInGame.Count == 1){
            playersHealthUI[0].playerHealthManager = playersInGame[0].GetComponent<HealthManager>();
            playersHealthUI[0].icon.enabled = true;
            playersHealthUI[0].InitiateHealthUI();
        }else{
            playersHealthUI[1].playerHealthManager = playersInGame[1].GetComponent<HealthManager>();
            playersHealthUI[1].InitiateHealthUI();
            playersHealthUI[1].icon.enabled = true;
            playerInputManager.enabled = false;
        }
    }

    
}
