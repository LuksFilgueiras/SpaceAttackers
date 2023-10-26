using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private int actualHealth;
    [SerializeField] private int maxHealth;

    void Awake(){
        actualHealth = maxHealth;
    }

    public void TakeDamage(int damage){
        actualHealth -= damage;

        if(actualHealth <= 0){
            Destroy(gameObject);
        }
    }

    
}
