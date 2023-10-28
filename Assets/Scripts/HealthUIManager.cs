using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HealthUIManager : MonoBehaviour
{
    public PlayerHealthUI[] playersHealthUI = new PlayerHealthUI[2];

    public PlayerInputManager playerInputManager;

    public void InitiateHealthUI(List<Player> players){
        if(players.Count == 1){
            playersHealthUI[0].playerHealthManager = players[0].GetComponent<HealthManager>();
            playersHealthUI[0].icon.enabled = true;
            playersHealthUI[0].InitiateHealthUI();
        }else{
            playersHealthUI[1].playerHealthManager = players[1].GetComponent<HealthManager>();
            playersHealthUI[1].InitiateHealthUI();
            playersHealthUI[1].icon.enabled = true;
        }
    }

    
}
