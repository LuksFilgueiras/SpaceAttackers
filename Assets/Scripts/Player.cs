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

    void Update()
    {
        Movement();
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

    float ScreenWidth(){
        float height = 2f * mainCam.orthographicSize;
        float width = height * mainCam.aspect;
        return width;
    }

    void ChangeShipSprite(int index){
        spriteRenderer.sprite = shipSprites[index];
    }
}
