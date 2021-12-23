using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace rpg
{   
    public enum WeaponType
    {
        glove,
        swords,
        range
    }

    public class Inventory_Button : MonoBehaviour
    {
        public WeaponHolder weaponHolder;
        public PlayerUI playerUI;
        public int gloveInt, swordInt, rangeInt;
        public TextMeshProUGUI weaponName;
        public WeaponType weaponType;
        public MeleeWeaponsSc meleeWeaponsSc;
        public RangeWeaponSC rangeWeaponSC;

        private void Start() 
        {   
            weaponName.text = "Empty";

            if(weaponHolder == null)
                weaponHolder = GameObject.FindGameObjectWithTag("Canvas").gameObject.GetComponent<PlayerUI>().weaponHolder;

            if(playerUI == null )
                playerUI = GameObject.FindGameObjectWithTag("Canvas").gameObject.GetComponent<PlayerUI>();

            if(weaponHolder == null)
                weaponHolder = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponentInChildren<WeaponHolder>();
        }

        private void Update() 
        {
            WeaponStats();    
        }
        public void WeaponStats()
        {
            switch (weaponType)
            {
                case WeaponType.glove: 
                    if(meleeWeaponsSc == null)
                        weaponName.text = "Empty";
                    else
                        weaponName.text = meleeWeaponsSc.meleeWeaponName;
                    break;
                case WeaponType.swords:
                    if(meleeWeaponsSc == null)
                        weaponName.text = "Empty";
                    else
                        weaponName.text = meleeWeaponsSc.meleeWeaponName;
                    break;
                case WeaponType.range:
                    if(rangeWeaponSC == null)
                        weaponName.text = "Empty";
                    else
                        weaponName.text = rangeWeaponSC.rangeWeaponName;
                    break;
            }
        }

        public void Remove()
        {
            meleeWeaponsSc = null;
            rangeWeaponSC = null;
            weaponName.text = "Empty";
        }
    
       public void EnableOrDisable_Weapon()
       {
            
            switch (weaponType)
            {    
               
                case WeaponType.glove:
                    EnableWeapon(weaponHolder.allLeftGloves, gloveInt);
                    EnableWeapon(weaponHolder.allRightGloves, gloveInt);
                    break;
                case WeaponType.swords:
                    EnableWeapon(weaponHolder.allSwords, swordInt);
                    break;
                case WeaponType.range:
                    EnableWeapon(weaponHolder.allRifle, rangeInt);
                    for (int i = 0; i < InventoryMain.Instance.inventoryRange.Count; i++)
                    {   
                        if(rangeWeaponSC != null && InventoryMain.Instance.inventoryRange[i] != null)
                            if(InventoryMain.Instance.inventoryRange[i].rangeWeaponName == rangeWeaponSC.rangeWeaponName){
                                rangeWeaponSC.currentUsed = true;
                                rangeWeaponSC.currentInventoryNum = rangeInt;
                            }
                            else
                                InventoryMain.Instance.inventoryRange[i].currentUsed = false;
                    }
                    break;
            }
            RifleActive();
            SetRifle();
       }

       public void RifleActive()
       {    
            if(rangeWeaponSC != null)
            {
                for (int i = 0; i < InventoryMain.Instance.inventoryRange.Count; i++)
                {   
                    if(InventoryMain.Instance.inventoryRange[i] != null)
                    {
                        if(rangeWeaponSC.rangeWeaponName == InventoryMain.Instance.inventoryRange[i].rangeWeaponName)
                            rangeWeaponSC.isActive = true;
                        else 
                            InventoryMain.Instance.inventoryRange[i].isActive = false;
                    }                     
                }
            }
       }

       public void SetRifle()
       {    
            if (rangeWeaponSC != null && rangeWeaponSC.currentUsed){
                weaponHolder.nextShoot = rangeWeaponSC.nextShoot;
                weaponHolder.nextShootTemp = rangeWeaponSC.nextShoot;
                weaponHolder.bulletTag = rangeWeaponSC.rangeWeaponName;
            } 
       }

       public void EnableWeapon(GameObject[] objects, int activeNum)
        {
            for (int i = 0; i < objects.Length; i++)
            {
                if(i == activeNum)
                    objects[i].SetActive(true);
                else
                    objects[i].SetActive(false);
            }
        }
    }
}


