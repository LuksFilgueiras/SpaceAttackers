using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] private HealthManager playerHealthManager;
    [SerializeField] private Transform heartsContainer;
    [SerializeField] private GameObject heartUIPrefab;
    private List<GameObject> hearts = new List<GameObject>();

    void Start(){
        playerHealthManager = FindObjectOfType<Player>().GetComponent<HealthManager>();

        for(int i = 0; i < playerHealthManager.getMaxHealth; i++){
            GameObject heartUIInstance = Instantiate(heartUIPrefab, heartsContainer);
            hearts.Add(heartUIInstance);
        }
    }

    void Update(){
        int maxHealth = playerHealthManager.getMaxHealth;
        int actualHealth = playerHealthManager.getActualHealth;

        for(int i = 0; i < maxHealth; i++){
            if(i >= actualHealth){
                hearts[i].GetComponentsInChildren<Image>()[1].enabled = false;
            }else{
                hearts[i].GetComponentsInChildren<Image>()[1].enabled = true;
            }
        }
    }
}
