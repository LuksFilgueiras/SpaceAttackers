using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class PickUp : MonoBehaviour
{
    public Rigidbody2D rigidBody2D;
    public PickUpType pickUpType;
    public TextMeshPro pickUpMessage;
    public string message;

    public float dropVelocityY = 0.5f;

    [Header("Effects")]
    public int healing = 0;
    public float shootingSpeedModifier = 0;
    public float moveSpeedModifier = 0;

    [Header("Destroy On Time")]
    public Animator animator;
    public float duration = 2f;

    public void Update(){
        rigidBody2D.velocity = new Vector2(0, -dropVelocityY);
        duration -= Time.deltaTime;
        if(duration <= 0f){
            animator.SetBool("isVanishing", true);
        }
    }

    public void ActivePickup(Player user){
        if(pickUpType == PickUpType.health){
            user.GetComponent<HealthManager>().RestoreHealth(1);
            DestroyGameObject();
        }
        else if(pickUpType == PickUpType.speed){
            user.AddMoveSpeedX(moveSpeedModifier);
            DestroyGameObject();
        }
        else if(pickUpType == PickUpType.firerate){
            user.ReduceShotDelayTimer(shootingSpeedModifier);
            DestroyGameObject();
        }else if(pickUpType == PickUpType.revive){
            // PARA PEGAR A LISTA DE JOGADORES
            PlayerManager playerManager = FindObjectOfType<PlayerManager>();
            foreach(PlayerInput player in playerManager.players){
                Player p = player.GetComponent<Player>();
                if(!player.gameObject.activeSelf){
                    player.gameObject.SetActive(true);
                    p.noDamageTimer = 1f;
                    p.GetComponent<HealthManager>().RestoreHealth(p.GetComponent<HealthManager>().getMaxHealth);
                    if(player.currentControlScheme == "PLAYER02" && p.onKeyboard && p.playerIndex > 0){
                        player.SwitchCurrentControlScheme("KEYBOARD02", Keyboard.current);
                    }
                    if(player.currentControlScheme == "PLAYER02" && p.playerIndex == 0){
                        player.SwitchCurrentControlScheme("PLAYER");
                        InputUser.PerformPairingWithDevice(Keyboard.current, player.user);
                        InputUser.PerformPairingWithDevice(Gamepad.all[0], player.user);
                    }
                    if(player.currentControlScheme == "PLAYER02" && !p.onKeyboard && p.playerIndex > 0){
                        player.SwitchCurrentControlScheme("PLAYER02");
                    }

                }
            }
            DestroyGameObject();
        }
    }

    public void DestroyGameObject(){
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "PlayerMissile" || col.tag == "Player"){
            if(col.GetComponent<PlayerMissile>()){
                ActivePickup(col.GetComponent<PlayerMissile>().player);
            }else{
                ActivePickup(col.GetComponent<Player>());
            }

            TextMeshPro messageInstance = Instantiate(pickUpMessage, transform.position, Quaternion.identity);
            messageInstance.text = message;
            Destroy(messageInstance, 0.8f);
        }
    }
}

public enum PickUpType{
    health,
    speed,
    firerate,
    revive
}
