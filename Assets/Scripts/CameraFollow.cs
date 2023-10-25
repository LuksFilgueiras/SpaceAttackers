using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float cameraOffSetY = 1.4f;

    void LateUpdate(){
        FollowPlayerYAxisOnly();
    }

    void FollowPlayerYAxisOnly(){
        transform.position = new Vector3(0, playerTransform.position.y + cameraOffSetY, -10f);
    }
}
