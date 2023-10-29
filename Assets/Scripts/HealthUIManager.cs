using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HealthUIManager : MonoBehaviour
{
    public PlayerHealthUI[] playersHealthUI = new PlayerHealthUI[2];

    void Awake(){
        Player.playerIndex = 0;
    }

    public void ShowHealthUI(Player player){
        playersHealthUI[Player.playerIndex].playerHealthManager = player.GetComponent<HealthManager>();
        playersHealthUI[Player.playerIndex].icon.enabled = true;
        playersHealthUI[Player.playerIndex].InitiateHealthUI();
    }

    
}
