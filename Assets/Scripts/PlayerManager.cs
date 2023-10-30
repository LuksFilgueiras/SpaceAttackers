using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public PlayerInputManager playerInputManager;
    public List<Player> playersInGame = new List<Player>();
    public Gamepad player02 = null;

    void Awake(){
        SetPlayer02GamePad();
    }
    void Update()
    {
        if(playersInGame.Count >= playerInputManager.maxPlayerCount){
            playerInputManager.enabled = false;
            return;
        }

        if(Input.GetKeyDown(KeyCode.Keypad0) && playersInGame.Count < playerInputManager.maxPlayerCount){
            PlayerInput.Instantiate(playerInputManager.playerPrefab, controlScheme: "KEYBOARD02", pairWithDevice: Keyboard.current);
        }

        if(Gamepad.all.Count > 1){
            if(player02.buttonSouth.isPressed && playersInGame.Count < playerInputManager.maxPlayerCount){
                PlayerInput.Instantiate(playerInputManager.playerPrefab, controlScheme: "PLAYER02");
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
                player02 = gamepad;
                break;
            }
        }
    }
}
