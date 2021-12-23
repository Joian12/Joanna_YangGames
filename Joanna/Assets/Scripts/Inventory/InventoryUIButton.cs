using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpg
{
    public class InventoryUIButton : MonoBehaviour
    {   
        public GameObject inventory;
        public GameObject weaponWindow;
        public GameObject armorWindow;
        public GameObject consumablesWindow;
        public GameObject controls;
        public GameObject weaponToggles;
        public GameObject glovesTab, swordsTab, rifleTab;
        public Inventory_Button[] buttonGloves;
        public Inventory_Button[] buttonSwords;
        public Inventory_Button[] buttonRange;
        public GameObject inventoryTab;
        public GameObject questTab;
        public Shop shop;

        private bool openInventory;

        private void Start()
        {
            openInventory = false;    
        }
  
        public void Update() 
        {    
            if(openInventory)
                Time.timeScale = 0.1f;
            else
                Time.timeScale = 1f;
        }

        public void Assign()
        {
            AssignMeleeToInventory(InventoryMain.Instance.inventoryGloves, buttonGloves);
            AssignMeleeToInventory(InventoryMain.Instance.inventorySwords, buttonSwords);
            AssignRangeToInventory(InventoryMain.Instance.inventoryRange, buttonRange);
        }

        public void AssignMeleeToInventory(List<MeleeWeaponsSc> list, Inventory_Button[] inventory_ButtonsList)
        {   
            for (int i = 0; i < list.Count; i++)
            {   
                inventory_ButtonsList[i].meleeWeaponsSc = list[i];
            }
        }

        public void AssignRangeToInventory(List<RangeWeaponSC> list, Inventory_Button[] inventory_ButtonsList)
        {   
            for (int i = 0; i < list.Count; i++)
            {
                inventory_ButtonsList[i].rangeWeaponSC = list[i];
            }
        }

        public void CheckActiveRifle(WeaponHolder weaponHolder){
            for (int i = 0; i < InventoryMain.Instance.inventoryRange.Count; i++){   
                if(InventoryMain.Instance.inventoryRange[i] == null)
                    return;
                    
                if (InventoryMain.Instance.inventoryRange[i].isActive == true){   
                    weaponHolder.nextShoot = InventoryMain.Instance.inventoryRange[i].nextShoot;
                    weaponHolder.nextShootTemp = InventoryMain.Instance.inventoryRange[i].nextShoot;
                    weaponHolder.bulletTag = InventoryMain.Instance.inventoryRange[i].rangeWeaponName;
                }
            }
        }
        
        public void OpenInventory(){    
            openInventory = !openInventory;
        
            inventory.SetActive(openInventory);
            controls.SetActive(!openInventory);
            questTab.SetActive(!openInventory);
            weaponToggles.SetActive(!openInventory);
        }
        public void OpenWeapon(){
            weaponWindow.SetActive(true);
            armorWindow.SetActive(false);
            consumablesWindow.SetActive(false);
        }   

        public void OpenArmor(){
            weaponWindow.SetActive(false);
            armorWindow.SetActive(true);
            consumablesWindow.SetActive(false);
        }

        public void Consumables(){   
            shop.PopulateItemsChest();
            weaponWindow.SetActive(false);
            armorWindow.SetActive(false);
            consumablesWindow.SetActive(true);
        }
    }
}


