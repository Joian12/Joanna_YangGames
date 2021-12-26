using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

namespace rpg
{
    public class EnemyStats : MonoBehaviour, IDamageble
    {
        public float currentHealth;
        public float maxHealth, exp; 
        public EnemyType enemyType;

        public Image healthBar;
        public float timerToDisable;
        public Animator anim;
        public string[] allAnims;
        public NavMeshAgent agent;

        private void Start() {   
            agent = GetComponent<NavMeshAgent>();
            timerToDisable = 5f;
        }

        public void TakeDamage(float damage){
            currentHealth -= damage;
            healthBar.fillAmount = currentHealth/maxHealth;
            Death();
        }

        public void Death(){
            
            if(currentHealth <= 0){
                agent.isStopped = true;
                anim.SetBool("death", true);
                for (int i = 0; i < allAnims.Length; i++){
                    anim.SetBool(allAnims[i], false);
                }
                gameObject.SetActive(false);
            }  
        }
        public void OnDisable(){   
            if(currentHealth <= 0){
                QuestManager.instance.AddKillQuest(this ,1);
                PlayerStats.instance.UpdateLevelUI(exp);
            }
        }
    }
}

