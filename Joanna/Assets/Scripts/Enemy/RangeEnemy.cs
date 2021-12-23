using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace rpg
{
    public class RangeEnemy : MonoBehaviour
    {
        private Transform player;
        public NavMeshAgent agent;
        public Animator anim;
        public float distanceToAttack;
        public GameObject projectile;
        public Transform projectileHolder;
        private float dis;
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
                
            transform.LookAt(player);
            dis = Vector3.Distance(player.position, transform.position);

            if(dis < distanceToAttack)
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

        public void SpawnProjectile()
        {
            Instantiate(projectile, projectileHolder.position, projectileHolder.rotation);
        }
    }
}


