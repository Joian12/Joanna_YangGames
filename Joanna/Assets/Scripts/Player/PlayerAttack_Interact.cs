using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace rpg
{
    public class PlayerAttack_Interact : MonoBehaviour{
        public PlayerInput playerInput;
        public Animator anim;
        public Vector2 input;
        int tempNum;
        public bool interacting, attack, pressingRight, shoot;
        I_Interact interact;
        GameObject others;
        string tagName;

        
        void Start(){   
            attack = true;
            interacting = false;
        }

        public void OnEnable(){
            playerInput.actions["Shoot"].performed += ctx => shoot = true;
            playerInput.actions["Shoot"].canceled += ctx => shoot = false;
        }
        void Update(){   
            Interacting();
        }

        public void PointAndShoot(){   
            input = playerInput.actions["Look At Range"].ReadValue<Vector2>();
         
            if(input == Vector2.zero){
                transform.rotation = transform.rotation;
            }else{
                Vector3 look = (transform.position + new Vector3(input.x, 0f, input.y)) - transform.position;
                Quaternion rot = Quaternion.LookRotation(look, Vector3.up);
                transform.rotation = Quaternion.Lerp(transform.rotation, rot, Time.deltaTime * 8f);
            }
        }
        public void Attack(){   
            var gamepad = Gamepad.current;
            if(gamepad != null)
                pressingRight = gamepad.rightTrigger.wasPressedThisFrame;
        }

        public void Interacting(){   
            interacting = (tagName == "Interactable" || tagName == "Destination");

            if(pressingRight && interacting && interact != null || shoot && interact != null){   
                interact.Interact();
                pressingRight = false;
            }
        }
       
        private void OnTriggerEnter(Collider other) {   
            tagName = other.tag;
            interact = other.gameObject.GetComponent<I_Interact>();
        }

        private void OnTriggerExit(Collider other) {   
            tagName = " ";
            interact = null;
        }

        
    }
}

