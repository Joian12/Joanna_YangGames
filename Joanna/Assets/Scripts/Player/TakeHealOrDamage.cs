using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpg{
    public class TakeHealOrDamage : MonoBehaviour, IDamageble{
        
        public float health; 
        PlayerStats playerStats;
        private void Start() {
            playerStats = PlayerStats.instance;
            playerStats.SetHealth(health);
        }
        private void Update() {
            
        }

        public void TakeDamage(float damage){

        }
    }
}

