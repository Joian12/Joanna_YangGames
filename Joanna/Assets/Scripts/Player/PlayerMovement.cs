using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

namespace rpg
{
    public class PlayerMovement : MonoBehaviour
    {   
        public PlayerInput playerInput;
        public Vector2 input;
        Vector3 horizontal;
        Vector3 vertical;
        public Vector3 movePos;
        Vector3 forwardPos;
        public NavMeshAgent agent;

        public float upDown;
        public bool touched;

        void Awake()
        {   
           touched = true;
        }
        
        public void Movement()
        {     
            if(touched)
                input = playerInput.actions["Movement"].ReadValue<Vector2>();
            else
                input = Vector2.zero;

            movePos = new Vector3(input.x, 0f, input.y);
            transform.position += movePos.normalized * Time.deltaTime * 7f; 
        }

        public void ShootingMovement()
        {  
            input = playerInput.actions["RangeMovement"].ReadValue<Vector2>();
            
            transform.position += new Vector3(input.x, 0f, input.y) * Time.deltaTime * 5f;
        }

        public void Rotation()
        {
            if(input == Vector2.zero)
            {
                transform.rotation = transform.rotation;
            }
            else
            {
                Vector3 look = (transform.position + new Vector3(input.x, 0f, input.y)) - transform.position;
                Quaternion rot = Quaternion.LookRotation(look, Vector3.up);
                transform.rotation = Quaternion.Lerp(transform.rotation, rot, Time.deltaTime * 14f);
            }
        }
    }
}


