using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody2D;
    [SerializeField] private float moveSpeedY = 1f;
    [SerializeField] private float moveSpeedX = 1.5f;
    [SerializeField] private bool isMovingLeft = false;
    [SerializeField] private float maxDistanceOffSet = 0.3f;


    [Header("Position on screen")]
    [SerializeField] private Camera mainCam;
    [SerializeField] private float enemyPositionOffsetY = 1f;


    void Awake(){
        mainCam = FindObjectOfType<Camera>();
    }

    void Update(){
        MovementBehaviour();
    }


    void MovementBehaviour(){
        float velocityY = -moveSpeedY;
        float positionYLimit = mainCam.orthographicSize - enemyPositionOffsetY;

        if(transform.position.y <= positionYLimit){
            velocityY = 0;
        }

        float horizontalMoveDistance = ScreenWidth() / 2 - maxDistanceOffSet;

        if(transform.position.x >= horizontalMoveDistance && !isMovingLeft){
            moveSpeedX *= -1f;
            isMovingLeft = true;
        }

        if(transform.position.x <= -horizontalMoveDistance && isMovingLeft){
            moveSpeedX *= -1f;
            isMovingLeft = false;
        }

        rigidBody2D.velocity = new Vector2(moveSpeedX, velocityY);
    }   

    float ScreenWidth(){
         float height = 2f * mainCam.orthographicSize;
         float width = height * mainCam.aspect;
         return width;
    }
}
