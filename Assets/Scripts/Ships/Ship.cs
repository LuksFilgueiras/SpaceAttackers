using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public Rigidbody2D rigidBody2D;
    public float moveSpeedX = 2f;
    public float maxDistanceOffSet = 0.3f;
    
    [Header("Health Component")]
    [SerializeField] protected HealthManager healthManager;
    
    
    [Header("Attack")]
    [SerializeField] protected GameObject missilePrefab;
    [SerializeField] protected float shotStrength = 4f;
    [SerializeField] protected float shotDelay = 0.1f;
    [SerializeField] protected float shotDelayTimer = 1.2f;
    [SerializeField] protected float destroyMissileInstanceTimer = 0.5f;

    [Header("Position on screen")]
    [SerializeField] protected Camera mainCam;

    
    [Header("Audio")]
    [SerializeField] protected AudioClip shootingSFX;
    protected AudioSource SFXSource;

    void Awake(){
        Cursor.visible = false;
        SFXSource = GameObject.FindGameObjectWithTag("SFXSource").GetComponent<AudioSource>();
        mainCam = FindObjectOfType<Camera>();
    }

    protected float ScreenWidth(){
        float height = 2f * mainCam.orthographicSize;
        float width = height * mainCam.aspect;
        return width;
    }


    protected virtual void ShotMissiles(){

    }
}
