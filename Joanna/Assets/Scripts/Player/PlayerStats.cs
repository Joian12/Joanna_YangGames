using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

namespace rpg
{
    public class PlayerStats : MonoBehaviour
    {   
        public static PlayerStats instance; 
        public float currentHealth;
        public float maxHealth; 
        public float currentArmor;
        public float maxArmor;
        private PlayerUI playerUI;
        public PlayerLevel playerLevel;

        private void Awake() {
            instance = this;
            playerLevel = GetComponent<PlayerLevel>();
            playerUI = GameObject.FindGameObjectWithTag("Canvas").gameObject.GetComponent<PlayerUI>();
        }

        public void SetHealth(float health){
            Debug.Log("called");
            currentHealth = health;
        }
        public void UpdateLevelUI(float exp){
            playerLevel.AddExp(exp);
            playerUI.levelText.text = playerLevel.level.ToString();
            playerUI.expBar.localScale = new Vector3(playerLevel.currentExp/playerLevel.maxExp, 1, 1);

        }
        public void UpdateHealthUI(){
            if(currentHealth <= maxHealth)
                playerUI.armor.localScale = new Vector3(currentArmor/maxArmor, 1, 1);
            if(currentHealth <= maxHealth)
                playerUI.health.localScale = new Vector3(currentHealth/maxHealth, 1, 1);
        }
    }   
}

