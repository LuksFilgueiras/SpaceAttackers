using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    
    [Header("Spawn")]
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private Transform spawnTransform;
    [SerializeField] private int enemyAmount = 3;
    [SerializeField] private int linesAmount = 2;
    [SerializeField] private float spaceBetweenLines = 0.5f;
    [SerializeField] private float timeBetweenEnemySpawned = 0.5f;

    public void Start(){
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies(){
        float linesSpacement = 0;
        for(int i = 0; i < linesAmount; i++){
            for(int j = 0; j < enemyAmount; j++){
                Enemy enemyInstance = Instantiate(enemyPrefab, spawnTransform.position, Quaternion.identity);
                if(i != 0){
                    enemyInstance.enemyPositionOffsetY += linesSpacement;
                }
                yield return new WaitForSeconds(timeBetweenEnemySpawned);
            }
            linesSpacement += spaceBetweenLines;
        }
    }

}
