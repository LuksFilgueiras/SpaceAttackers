using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private int actualHealth;
    [SerializeField] private int maxHealth;
    [SerializeField] private GameObject explosionVFX;
    [SerializeField] private Animator animator;


    [Header("Audio")]
    [SerializeField] private AudioClip explosionSFX;
    [SerializeField] private AudioClip hitSFX;
    private AudioSource sfxSource;

    public int getActualHealth{
        get{return actualHealth;}
    }

    public int getMaxHealth{
        get{return maxHealth;}
    }

    void Awake(){
        sfxSource = GameObject.FindGameObjectWithTag("SFXSource").GetComponent<AudioSource>();
        actualHealth = maxHealth;
    }

    public void RestoreHealth(int health){
        actualHealth += health;

        if(actualHealth >= maxHealth){
            actualHealth = maxHealth;
        }
    }

    public void TakeDamage(int damage){
        actualHealth -= damage;
        animator.SetTrigger("Hit");
        
        if(actualHealth > 0){
            sfxSource.PlayOneShot(hitSFX);
        }

        if(actualHealth <= 0){
            GameObject explosionVFXInstance = Instantiate(explosionVFX, transform.position, Quaternion.identity);
            Destroy(explosionVFXInstance, 0.45f);
            sfxSource.PlayOneShot(explosionSFX);
            Destroy(gameObject);
        }
    }
    
}
