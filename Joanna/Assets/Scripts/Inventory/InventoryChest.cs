using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpg
{
    public class InventoryChest : MonoBehaviour, I_Interact
    {   
        public GameObject inventoryChestUI, control, weaponToggles , weapons;
        public GameObject gloves;
        public GameObject weaponItem;
        public GameObject canvas;
        public InventoryUIButton invetoryUIB;
        public InventoryChestButtons inventoryChestButtons;
     

        private void Start()
        {   
            canvas = GameObject.FindGameObjectWithTag("Canvas").gameObject;
            inventoryChestUI = canvas.transform.GetChild(4).gameObject;   
            weapons = inventoryChestUI.transform.GetChild(0).gameObject;
            gloves = weapons.transform.GetChild(0).gameObject;
            control = canvas.transform.GetChild(0).gameObject;   
            weaponToggles = canvas.transform.GetChild(1).gameObject; 
            inventoryChestUI.SetActive(false);
            invetoryUIB = canvas.GetComponent<InventoryUIButton>();
            inventoryChestButtons = canvas.GetComponentInChildren<InventoryChestButtons>();
        }

        public void Interact()
        {   
            inventoryChestButtons.InitiliazeChestInventory();
            inventoryChestUI.SetActive(true);
            control.SetActive(false);
            weaponToggles.SetActive(false);
            invetoryUIB.questTab.SetActive(false);
            invetoryUIB.inventoryTab.SetActive(false);
        }

        public void DeInteract()
        {

        }

    }
}

