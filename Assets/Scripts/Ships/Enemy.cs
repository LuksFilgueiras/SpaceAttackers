using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Ship
{
    [SerializeField] private float moveSpeedY = 1f;
    public bool isMovingLeft = false;
    public bool isPositioned = false;
    public float enemyPositionOffsetY = 1f;
    public Collider2D bodyCollider;

    [Header("Score")]
    public int scorePoints = 10;
    
    void Update(){
        EnemyBehaviour();
    }

    void EnemyBehaviour(){
        if(!isPositioned){
            bodyCollider.enabled = false;
        }else{
            bodyCollider.enabled = true;
        }

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
            ShotMissiles();
        }

        rigidBody2D.velocity = new Vector2(moveSpeedX, velocityY);
    }   

    protected override void ShotMissiles(){
        if(shotDelay <= 0){
            GameObject missileInstance = Instantiate(missilePrefab, transform.position, Quaternion.identity);
            missileInstance.GetComponent<Rigidbody2D>().AddForce(Vector2.down * shotStrength, ForceMode2D.Impulse);
            missileInstance.transform.rotation = Quaternion.Euler(0, 0, 180f);
            Destroy(missileInstance, destroyMissileInstanceTimer);
            shotDelay = shotDelayTimer;

            SFXSource.PlayOneShot(shootingSFX);
        }else{
            shotDelay -= Time.deltaTime;
        }
    }

    public void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "PlayerMissile"){
            if(healthManager.getActualHealth == 1){
                FindObjectOfType<Player>().AddScore(scorePoints);
            }
            healthManager.TakeDamage(1);
            Destroy(col.gameObject);
        }
    }
}
