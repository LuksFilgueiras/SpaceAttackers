using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Camera mainCam;
    [SerializeField] private Rigidbody2D rigidBody2D;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float maxDistanceOffSet = 0.3f;

    [Header("Sprites Animation")]
    [SerializeField] private Sprite[] shipSprites;

    [Header("Shooting")]
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private float shotStrength;
    [SerializeField] private float shotDelay = 0f;
    [SerializeField] private float shotDelayTimer = 0.3f;
    [SerializeField] private float destroyMissileInstanceTimer = 0.5f;

    void Update()
    {
        Movement();
        Shoot();
    }

    void Movement(){
        float x = Input.GetAxis("Horizontal");

        rigidBody2D.velocity = new Vector2(x * moveSpeed, 0);

        float maxDistance = ScreenWidth() / 2 - maxDistanceOffSet;

        if(x > 0){
            ChangeShipSprite(1);
        }else if(x < 0){
            ChangeShipSprite(2);
        }else{
            ChangeShipSprite(0);
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -maxDistance, maxDistance), transform.position.y, 0);
    }

    void Shoot(){
        if(Input.GetKey(KeyCode.T) && shotDelay <= 0f){
            GameObject missileInstance = Instantiate(missilePrefab, transform.position, Quaternion.identity);
            missileInstance.GetComponent<Rigidbody2D>().AddForce(Vector2.up * shotStrength, ForceMode2D.Impulse);
            Destroy(missileInstance, destroyMissileInstanceTimer);
            shotDelay = shotDelayTimer;
        }
        else{
            shotDelay -= Time.deltaTime;
        }
    }

    float ScreenWidth(){
        float height = 2f * mainCam.orthographicSize;
        float width = height * mainCam.aspect;
        return width;
    }

    void ChangeShipSprite(int index){
        spriteRenderer.sprite = shipSprites[index];
    }
}
