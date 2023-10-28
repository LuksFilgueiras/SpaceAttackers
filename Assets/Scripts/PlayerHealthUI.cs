using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHealthUI : MonoBehaviour
{
    public HealthManager playerHealthManager;
    public Transform heartsContainer;
    public GameObject heartUIPrefab;
    public Image icon;
    private List<GameObject> hearts = new List<GameObject>();
    

    public void InitiateHealthUI(){
        for(int i = 0; i < playerHealthManager.getMaxHealth; i++){
            GameObject heartUIInstance = Instantiate(heartUIPrefab, heartsContainer);
            hearts.Add(heartUIInstance);
        }
    }

    void Update(){
        if(playerHealthManager == null){
            if(hearts.Count > 0){
                foreach(GameObject heart in hearts){
                    heart.GetComponentsInChildren<Image>()[1].enabled = false;
                }
            }
            return;
        }

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
