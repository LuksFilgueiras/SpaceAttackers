using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundBehaviour : MonoBehaviour
{
    public SpriteRenderer[] backgrounds;
    public float backgroundSpeed = 0.001f;
    public float positionY = 3.9f;

    void Update(){
        transform.position += new Vector3(0, -backgroundSpeed, 0);

        if(transform.position.y <= -positionY && backgrounds[0].transform.position.y <= -positionY){
            backgrounds[0].transform.position = new Vector3(0, positionY, 0);
            SpriteRenderer backgroundSwapped = backgrounds[0];
            backgrounds[0] = backgrounds[1];
            backgrounds[1] = backgroundSwapped;
        }
    }
}
