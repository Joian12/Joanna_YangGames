using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

namespace rpg
{
    public class PlayerStats : MonoBehaviour, IDamageble
    {   
        public PlayableDirector playableDirector;   
        public float currentHealth;
        public float maxHealth; 
        public float currentArmor;
        public float maxArmor;

        public void TakeDamage(float damage)
        {
            currentArmor -= damage;
            if(currentArmor <= 0)
            {
                currentArmor = 0;
                currentHealth -= damage;
                if(currentHealth <= 0)
                {
                    currentHealth = 0;
                    DieStatus();
                }
            }
        }

        public void DieStatus()
        {
            gameObject.SetActive(false);
        }

        private void OnDisable() 
        {   
            if(currentHealth <= 0)
            {
                playableDirector.Play();
            }  
        }
    }   
}

