using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public PlayerInputManager playerInputManager;
    public List<Player> playersInGame = new List<Player>();

    void Update()
    {
        if(Gamepad.all[1].buttonSouth.isPressed && playersInGame.Count < playerInputManager.maxPlayerCount){
            PlayerInput.Instantiate(playerInputManager.playerPrefab, controlScheme: "PLAYER02");
        }
        else if(Input.GetKeyDown(KeyCode.Keypad0) && playersInGame.Count < playerInputManager.maxPlayerCount){
            PlayerInput.Instantiate(playerInputManager.playerPrefab, controlScheme: "KEYBOARD02", pairWithDevice: Keyboard.current);
        }else{
            playerInputManager.enabled = false;
        }
    }
}
