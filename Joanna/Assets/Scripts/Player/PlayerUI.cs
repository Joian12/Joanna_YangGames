using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace rpg
{   
    public enum WeaponState
    {
        box,
        swords,
        rifle
    }
    public class PlayerUI : MonoBehaviour
    {      
        public GameObject rightButton, rightStick, upDown, left;
        public GameObject interactUI;
        public PlayerAnimationState playerAnimationState;
        public PlayerMovement playerMovement;
        public PlayerAttack_Interact playerAttack_Interact;
        public WeaponHolder weaponHolder;
        public PlayerStats playerStats;
        public RectTransform health;
        public RectTransform armor;
        public Animator anim;

        public int currentGloves;
        public int currentSwords;
        public int currentRange;

        private void Awake() 
        {   
            playerStats = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<PlayerStats>();
            playerMovement = playerStats.gameObject.GetComponent<PlayerMovement>();
            weaponHolder = playerStats.gameObject.GetComponentInChildren<WeaponHolder>();
            playerAttack_Interact = playerStats.gameObject.GetComponent<PlayerAttack_Interact>();
            playerAnimationState = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<PlayerAnimationState>();
            anim = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<PlayerStats>().gameObject.GetComponentInChildren<Animator>();
            
            Switch_Box();
        }
        void Update()
        {     
            armor.localScale = new Vector3(playerStats.currentArmor/playerStats.maxArmor, 1, 1);
            health.localScale = new Vector3(playerStats.currentHealth/playerStats.maxHealth, 1, 1);
            interactUI.SetActive(playerAttack_Interact.interacting);
        }

        public void Switch_Box()
        {   
            rightButton.SetActive(true);
            rightStick.SetActive(false);
            left.SetActive(true);
            upDown.SetActive(false);
            playerAnimationState.weaponState = WeaponState.box;
            weaponHolder.DisableWeapon(WeaponState.box);
            anim.SetBool("MeleeMovement",true);
            anim.SetBool("RangeMovement",false);
            anim.SetBool("swords", false);
            anim.SetBool("rifle", false);
            anim.SetBool("box", true);
        }

        public void Switch_Swords()
        {   
            rightButton.SetActive(true);
            rightStick.SetActive(false);
            left.SetActive(true);
            upDown.SetActive(false);
            playerAnimationState.weaponState = WeaponState.swords;
            weaponHolder.DisableWeapon(WeaponState.swords);
            anim.SetBool("MeleeMovement",true);
            anim.SetBool("RangeMovement",false);
            anim.SetBool("box", false);
            anim.SetBool("rifle", false);
            anim.SetBool("swords", true);
        }

        public void Switch_Rifle()
        {   
            rightButton.SetActive(false);
            rightStick.SetActive(true);
            left.SetActive(true);
            //upDown.SetActive(true);
            playerAnimationState.weaponState = WeaponState.rifle;
            weaponHolder.DisableWeapon(WeaponState.rifle);
            weaponHolder.InstantiateCurrentRifle();
            anim.SetBool("box", false);
            anim.SetBool("swords", false);
            anim.SetBool("rifle", true);
        }
    }
}

