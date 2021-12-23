using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.Playables;

namespace rpg
{
    public class BossBull : MonoBehaviour, IDamageble
    {   
        public PlayableDirector playableDirector;
        public float currentHealth;
        public float maxHealth;
        public Transform player;
        private Transform myTransform;
        public float dis;
        public float disToAttack;
        public Animator anim;
        public NavMeshAgent agent;
        public float walkSpeed;
        public float runSpeed;
        public Image health;
        public string[] animNames;
        private int randNum;

        private float secToChange;

        private void Awake() 
        {
            player = GameObject.FindGameObjectWithTag("Player").gameObject.transform;
            myTransform = transform;
            secToChange = 6f;
        }

        private void Update()
        {   
           
            health.fillAmount = currentHealth/maxHealth;
            dis = Vector3.Distance(myTransform.position, player.position);

            Death();

            if(currentHealth <= 0)
                return;

            myTransform.LookAt(player.position);
            if(currentHealth/maxHealth < 0.5f)
            {
                RageMode();
            }
            else
            {
                secToChange -= Time.deltaTime;

                if(secToChange <= 0)
                {   
                    randNum = Random.Range(0,3);
                    secToChange = 6f;
                }

                ChaseAndAttack();
                switch (randNum)
                {
                    case 0:
                        ChaseAndAttack();
                            break;
                    case 1:
                        Taunt();
                            break;
                    case 2: 
                        Idle();
                            break;
                }
            }
        }

        private void ChaseAndAttack()
        {    
            anim.SetBool("taunt", false);
            AdjustSpeedandAnim("walk", "attack", walkSpeed);
        }
        
        private void Taunt()
        {
            agent.isStopped = true;
            anim.SetBool("attack", false);
            anim.SetBool("walk", false);
            anim.SetBool("taunt", true);
        }

        private void Idle()
        {   
            agent.isStopped = true;
            for (int i = 0; i < animNames.Length; i++)
            {
                anim.SetBool(animNames[i], false);
            }
        }

        private void RageMode()
        {   
            anim.SetBool("attack", false);
            anim.SetBool("walk", false);
            anim.SetBool("taunt", false);
            AdjustSpeedandAnim("run", "rageAttack", runSpeed);
        }

        public void TakeDamage(float damage)
        {
            currentHealth -= damage;
            if(currentHealth <= 0)
            {
                currentHealth = 0f;
            }
        }   
        public void AdjustSpeedandAnim(string stringName, string attackName, float speed)
        {
             agent.speed = speed;

            if(dis < disToAttack)
            {
                agent.isStopped = true;
                anim.SetBool(stringName, false);
                anim.SetBool(attackName, true);
            }
            else
            {   
                anim.SetBool(attackName, false);
                anim.SetBool(stringName, true);
                agent.isStopped = false;
                agent.SetDestination(player.position);
            }
        }

        public void Death()
        {
            if(currentHealth <= 0)
            {   
                agent.isStopped = true;
                for (int i = 0; i < animNames.Length; i++)
                {
                    anim.SetBool(animNames[i], false);
                }

                anim.SetBool("death", true);
            }
        }

        private void OnDisable()
        {
            playableDirector.Play();
        }
    }
}

