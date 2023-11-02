using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class PlayerManager : MonoBehaviour
{
    public HealthUIManager healthUIManager;
    public PlayerInputManager playerInputManager;
    public GameObject player01Prefab = null;
    public Gamepad secondGamepad = null;
    public List<PlayerInput> players = new List<PlayerInput>();

    void Awake(){
        PlayerInput player01 = PlayerInput.Instantiate(player01Prefab, controlScheme: "PLAYER", pairWithDevice: Keyboard.current);
        players.Add(player01);
        player01.GetComponent<Player>().SetPlayerIndex(0);
        healthUIManager = FindObjectOfType<HealthUIManager>();
        healthUIManager.ShowHealthUI(player01.GetComponent<Player>());
        SetPlayer02GamePad();
    }
    void Update()
    {
        if(players.Count >= playerInputManager.maxPlayerCount){
            playerInputManager.enabled = false;
            return;
        }

        if(Input.GetKeyDown(KeyCode.Keypad0) && players.Count < playerInputManager.maxPlayerCount){
            PlayerInput player02 = PlayerInput.Instantiate(playerInputManager.playerPrefab, controlScheme: "KEYBOARD02", pairWithDevice: Keyboard.current);
            players.Add(player02);
            player02.GetComponent<Player>().onKeyboard = true;
            player02.GetComponent<Player>().SetPlayerIndex(1);
            healthUIManager.ShowHealthUI(player02.GetComponent<Player>());
        }

        if(Gamepad.all.Count > 1){
            if(secondGamepad.buttonSouth.isPressed && players.Count < playerInputManager.maxPlayerCount){
                PlayerInput player02 = PlayerInput.Instantiate(playerInputManager.playerPrefab, controlScheme: "PLAYER02");
                players.Add(player02);
                player02.GetComponent<Player>().SetPlayerIndex(1);
                healthUIManager.ShowHealthUI(player02.GetComponent<Player>());
            }
        }
    }

    public void SetPlayer02GamePad(){
        if(Gamepad.all.Count == 0){
            return;
        }
        
        int currentGamepadId = Gamepad.current.deviceId;

        foreach(Gamepad gamepad in Gamepad.all){
            if(gamepad.deviceId != currentGamepadId){
                secondGamepad = gamepad;
                break;
            }
        }
    }
}
