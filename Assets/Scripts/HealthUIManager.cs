using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HealthUIManager : MonoBehaviour
{
    public PlayerHealthUI[] playersHealthUI = new PlayerHealthUI[2];

    public void ShowHealthUI(Player player){
        playersHealthUI[player.playerIndex].playerHealthManager = player.GetComponent<HealthManager>();
        playersHealthUI[player.playerIndex].icon.enabled = true;
        playersHealthUI[player.playerIndex].InitiateHealthUI();
    }

    
}
