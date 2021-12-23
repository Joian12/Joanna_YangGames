using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

namespace rpg
{
    public class PlayerAnimationState : MonoBehaviour
    {
        public WeaponState weaponState;
        public Animator anim;
        public PlayerInput playerInput;
        public PlayerMovement playerMovement;
        public PlayerAttack_Interact playerAttack_Interact;
        public NavMeshAgent agent;
        int attackNum;
        public bool run;
        float z;
        public string animPlaying;
        public float upDown;
        float angle;
        
        private void Awake() 
        {
            anim.SetBool("MeleeMovement",true);
            attackNum = 0;
        }

        void Update()
        {      
            Vector3 targetDir = (transform.position + new Vector3(playerMovement.input.x, 0f, playerMovement.input.y)) - transform.position;
            angle = Vector3.Angle(transform.forward, targetDir);

            switch (weaponState)
            {   
                case WeaponState.box:
                    playerMovement.Movement();
                    playerMovement.Rotation();
                    anim.SetFloat("vertical", 0);
                    MeleeMovement();
                    AttackAnimation("box_", 2);
                        break;
                case WeaponState.swords:
                    playerMovement.Movement();
                    playerMovement.Rotation();
                    anim.SetFloat("vertical", 0);
                    MeleeMovement();
                    AttackAnimation("sword_", 3);
                        break;
                case WeaponState.rifle:

                    attackNum = 0;
      
                    if(playerAttack_Interact.shoot)
                    {   
                        anim.SetBool("run", false);
                        anim.SetBool("RangeMovement", true);
                        anim.SetBool("MeleeMovement", false);
                        anim.SetBool("shoot", true);
                        playerAttack_Interact.PointAndShoot();
                        playerMovement.ShootingMovement();
                        ShootingMovement();
                    }
                    else
                    {   
                        anim.SetBool("run", run);
                        anim.SetBool("MeleeMovement", true);
                        anim.SetBool("RangeMovement", false);
                        anim.SetBool("shoot", false);
                        playerMovement.Movement();
                        MeleeMovement();
                        playerMovement.Rotation();
                    }                 
                    break;
            }
        }

        public float Inverter(float look, float move)
        {
            if(look < 0f)
                return move *= -1f;
            else
                return move *= 1f;
        }

        public void ShootingMovement()
        {  
            Vector3 x = playerMovement.input.x * Vector3.right;
            Vector3 z = playerMovement.input.y * Vector3.forward;

            Vector3 newInput = (x + z);
            Vector3 inverseInput = transform.InverseTransformDirection(newInput);

            anim.SetFloat("horizontal", inverseInput.x);
            anim.SetFloat("vertical", inverseInput.z);
        }
        public void MeleeMovement()
        {   
            anim.SetBool("run", run);
        }

        public void AttackAnimation(string attackName, int animCount)
        {   
            playerAttack_Interact.Attack();
            if(playerAttack_Interact.interacting)
                return;

            if(playerAttack_Interact.pressingRight && playerAttack_Interact.attack)
            {       
                anim.Play(attackName+attackNum);
                animPlaying = attackName+attackNum.ToString();
                attackNum = attackNum == animCount ? attackNum = 0 : attackNum += 1; 
            }

            if (anim.GetCurrentAnimatorStateInfo(1).IsName(animPlaying))
                playerAttack_Interact.attack = false;
            else
                playerAttack_Interact.attack = true;
        }
    }
}

