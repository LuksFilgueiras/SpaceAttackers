using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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

    public void ActivePickup(){
        if(pickUpType == PickUpType.health){
            FindObjectOfType<Player>().GetComponent<HealthManager>().RestoreHealth(1);
            DestroyGameObject();
        }
        else if(pickUpType == PickUpType.speed){
            FindObjectOfType<Player>().AddMoveSpeedX(moveSpeedModifier);
            DestroyGameObject();
        }
        else if(pickUpType == PickUpType.firerate){
            FindObjectOfType<Player>().ReduceShotDelayTimer(shootingSpeedModifier);
            DestroyGameObject();
        }else if(pickUpType == PickUpType.revive){
            // PARA PEGAR A LISTA DE JOGADORES
            PlayerManager playerManager = FindObjectOfType<PlayerManager>();
            foreach(Player player in playerManager.playersInGame){
                if(!player.gameObject.activeSelf){
                    player.gameObject.SetActive(true);
                    player.noDamageTimer = 1f;
                    player.GetComponent<HealthManager>().RestoreHealth(player.GetComponent<HealthManager>().getMaxHealth);
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
            ActivePickup();
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
