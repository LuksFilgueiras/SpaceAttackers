using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private ChatManager chatManager;

    [Header("Spawn")]
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private Transform spawnTransform;
    [SerializeField] private int enemyAmount = 0;
    [SerializeField] private int linesAmount = 1;
    [SerializeField] private float spaceBetweenLines = 0.5f;
    [SerializeField] private float timeBetweenEnemySpawned = 0.5f;

    [Header("Waves")]
    [SerializeField] private float delayBetweenWaves = 0f;
    [SerializeField] private float delayBetweenWavesTimer = 1f;

    public List<Enemy> enemiesInBattlefield = new List<Enemy>();
    bool isAllEnemiesInBattleField = false;
    bool isAllEnemiesDestroyed = true;

    public void Start(){
        chatManager = FindObjectOfType<ChatManager>();
        delayBetweenWaves = delayBetweenWavesTimer;
    }

    public void Update(){
        ClearEnemiesIfAllDestroyed();
        SendWaves();
    }

    void SendWaves(){
        if(!chatManager.isChatFinished){
            return;
        }

        if(isAllEnemiesDestroyed && delayBetweenWaves > 0){
            delayBetweenWaves -= Time.deltaTime;
        }

        if(isAllEnemiesDestroyed && delayBetweenWaves <= 0){
            NewRandomDifficulty();
            StartCoroutine(SpawnEnemies());
            isAllEnemiesDestroyed = false;
            delayBetweenWaves = delayBetweenWavesTimer;
        }
    }

    void NewRandomDifficulty(){
        int isEnemyAmount = Random.Range(0, 2);

        if(enemyAmount == 0){
            enemyAmount++;
            return;
        }

        if(isEnemyAmount > 0 && linesAmount < 4 && enemyAmount > 2){
            if(enemyAmount > 1){
                enemyAmount--;
            }

            linesAmount++;
        }else{
            if(linesAmount < 4 && enemyAmount >= 5){
                linesAmount++;
                enemyAmount--;
            }else{
                enemyAmount++;
            }
        }
    }

    void ClearEnemiesIfAllDestroyed(){
        if(isAllEnemiesInBattleField){
            int enemiesCount = 0;
            foreach(Enemy enemy in enemiesInBattlefield){
                if(enemy == null){
                    enemiesCount++;
                }
            }

            if(enemiesCount == enemiesInBattlefield.Count){
                isAllEnemiesInBattleField = false;
                isAllEnemiesDestroyed = true;
                enemiesInBattlefield.Clear();
            }
        }
    }

    IEnumerator SpawnEnemies(){
        float linesSpacement = 0;
        for(int i = 0; i < linesAmount; i++){
            for(int j = 0; j < enemyAmount; j++){
                Enemy enemyInstance = Instantiate(enemyPrefab, spawnTransform.position, Quaternion.identity);
                if(i != 0){
                    enemyInstance.enemyPositionOffsetY += linesSpacement;
                }
                enemiesInBattlefield.Add(enemyInstance);
                yield return new WaitForSeconds(timeBetweenEnemySpawned);
            }
            linesSpacement += spaceBetweenLines;
        }
        
        isAllEnemiesInBattleField = true;
    }

}
