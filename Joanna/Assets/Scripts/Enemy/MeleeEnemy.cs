using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace rpg
{   
    public class MeleeEnemy : MonoBehaviour
    {   
        public float disToAttack;
        public float disToOldPos_;
        public Transform player;

        public NavMeshAgent agent;
        public Animator anim;
        private float dis;
        private float disToOldPos;
        private Vector3 oldPos;
        EnemyStats stats;
        
        void Start()
        {   
            stats = GetComponent<EnemyStats>();
            oldPos = transform.position;
            player = GameObject.FindGameObjectWithTag("Player").gameObject.transform;
            
        }

        void Update()
        {   
            if(stats.currentHealth <= 0)
                return;
            
            disToOldPos = Vector3.Distance(player.position, oldPos);
            dis = Vector3.Distance(player.position, transform.position);

            if(disToOldPos < disToOldPos_)
            {   
                transform.LookAt(player);
                if(dis < disToAttack)
                {
                    anim.SetBool("run", false);
                    anim.SetBool("attack", true);
                    agent.isStopped = true;
                }
                else
                {   
                    anim.SetBool("attack", false);
                    anim.SetBool("run", true);
                    agent.isStopped = false;
                    agent.SetDestination(player.position);
                }
            }
            else
            {      
                oldPos = new Vector3(oldPos.x, transform.position.y, oldPos.z);
                transform.LookAt(oldPos);
                agent.SetDestination(oldPos);
            }    
        }

        
    }
}

