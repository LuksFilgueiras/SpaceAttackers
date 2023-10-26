using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody2D;
    [SerializeField] private float moveSpeedY = 1f;
    [SerializeField] private float moveSpeedX = 1.5f;
    [SerializeField] private float maxDistanceOffSet = 0.3f;
    public bool isMovingLeft = false;
    public bool isPositioned = false;


    [Header("Position on screen")]
    [SerializeField] private Camera mainCam;
    public float enemyPositionOffsetY = 1f;

    [Header("Health Component")]
    [SerializeField] private HealthManager healthManager;

    [Header("Enemy Attack")]
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private float shootStrength = 4f;
    [SerializeField] private float shootDelay = 0.1f;
    [SerializeField] private float shootDelayTimerMin = 1.2f;
    [SerializeField] private float shootDelayTimerMax = 1.8f;


    void Awake(){
        mainCam = FindObjectOfType<Camera>();
    }

    void Update(){
        EnemyBehaviour();
    }

    void EnemyBehaviour(){
        float velocityY = -moveSpeedY;
        float positionYLimit = mainCam.orthographicSize - enemyPositionOffsetY;

        if(transform.position.y <= positionYLimit){
            velocityY = 0;
            isPositioned = true;
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

        if(velocityY == 0){
            Shooting();
        }

        rigidBody2D.velocity = new Vector2(moveSpeedX, velocityY);
    }   

    void Shooting(){
        if(shootDelay <= 0){
            GameObject missileInstance = Instantiate(missilePrefab, transform.position, Quaternion.identity);
            missileInstance.GetComponent<Rigidbody2D>().AddForce(Vector2.down * shootStrength, ForceMode2D.Impulse);
            Destroy(missileInstance, 0.7f);
            shootDelay = Random.Range(shootDelayTimerMin, shootDelayTimerMax);
        }else{
            shootDelay -= Time.deltaTime;
        }
    }

    float ScreenWidth(){
         float height = 2f * mainCam.orthographicSize;
         float width = height * mainCam.aspect;
         return width;
    }

    public void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "PlayerMissile"){
            healthManager.TakeDamage(1);
            Destroy(col.gameObject);
        }
    }
}
