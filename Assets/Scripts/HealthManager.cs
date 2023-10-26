using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private int actualHealth;
    [SerializeField] private int maxHealth;
    [SerializeField] private GameObject explosionVFX;
    [SerializeField] private Animator animator;

    void Awake(){
        actualHealth = maxHealth;
    }

    public void TakeDamage(int damage){
        actualHealth -= damage;
        animator.SetTrigger("Hit");

        if(actualHealth <= 0){
            GameObject explosionVFXInstance = Instantiate(explosionVFX, transform.position, Quaternion.identity);
            Destroy(explosionVFXInstance, 0.45f);
            Destroy(gameObject);
        }
    }

    
}
