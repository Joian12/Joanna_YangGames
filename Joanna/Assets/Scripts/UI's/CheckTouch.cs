using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace rpg
{
    public class CheckTouch : MonoBehaviour, IDragHandler, IEndDragHandler
    {   
        public RectTransform stick; 
        public PlayerUI playerUI;
        public PlayerAnimationState playerAnimationState;
        public PlayerMovement playerMovement;
        public Vector2 position;

        private void Awake() {
            if(stick != null)
                position =  stick.anchoredPosition;
        }

        public void Update()
        {
            if(playerAnimationState == null)
                playerAnimationState = playerUI.playerAnimationState;

            if(playerMovement == null)
                playerMovement = playerUI.playerMovement;
        }
        private void OnDisable() {

            playerAnimationState.run = false;
            playerMovement.touched = false; 
            //playerAnimationState.upDown = 0f;
        }

        private void OnEnable() {
            if(stick != null)
                stick.anchoredPosition = position;
            
            //playerAnimationState.upDown = 0f;
        }

        public void OnDrag(PointerEventData eventData)
        {
            playerMovement.touched = true;  
            playerAnimationState.run = true; 
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            playerAnimationState.run = false;   
            playerMovement.touched = false;     
        }
    }
}


