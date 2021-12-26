using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpg
{
    public class WeaponHolder : MonoBehaviour
    {   
        public Transform rightGlovesHolder, leftGlovesHolder;
        public Transform swordHolder;
        public Transform rifleHolder;

        public GameObject[] allLeftGloves;
        public GameObject[] allRightGloves;
        public GameObject[] allSwords;
        public GameObject[] allRifle;

        public GameObject projectileSpawner;
        public PlayerAttack_Interact pAttack;
        public string bulletTag;
        public int gloveInt, swordInt, rangeInt;

        public float nextShoot;
        public float nextShootTemp;
        
        private void Start() {
           
        }
        private void Update() 
        {
            Shooting();    
        }

        public void AssignGloves()
        {    
            for (int i = 0; i < InventoryMain.Instance.inventoryGloves.Count; i++)
            {   
                if(InventoryMain.Instance.inventoryGloves[i] != null)
                {   
                    int a = allLeftGloves[i].transform.childCount;

                    if(a != 1)
                    {
                        GameObject left = Instantiate(InventoryMain.Instance.inventoryGloves[i].boxingGloves[0]);
                        GameObject right = Instantiate(InventoryMain.Instance.inventoryGloves[i].boxingGloves[1]);
                        left.transform.SetParent(allLeftGloves[i].transform);
                        right.transform.SetParent(allRightGloves[i].transform);
                        left.transform.localPosition = InventoryMain.Instance.inventoryGloves[i].boxPosition[0];
                        right.transform.localPosition = InventoryMain.Instance.inventoryGloves[i].boxPosition[1];
                        Quaternion leftRot = Quaternion.Euler(InventoryMain.Instance.inventoryGloves[i].boxRotation[0]);
                        Quaternion rightRot = Quaternion.Euler(InventoryMain.Instance.inventoryGloves[i].boxRotation[1]);
                        left.transform.localRotation = leftRot;
                        right.transform.localRotation = rightRot;
                    }
                } 
            }
        }

        public void AssignSwords()
        {
            for (int i = 0; i < InventoryMain.Instance.inventorySwords.Count; i++)
            {   
                if(InventoryMain.Instance.inventorySwords[i] != null)
                {
                    int a = allSwords[i].transform.childCount;

                    if(a != 1)
                    {
                        GameObject swords = Instantiate(InventoryMain.Instance.inventorySwords[i].weapon);
                        swords.transform.SetParent(allSwords[i].transform);
                        swords.transform.localPosition = InventoryMain.Instance.inventorySwords[i].position;
                        Quaternion swordRot = Quaternion.Euler(InventoryMain.Instance.inventorySwords[i].rotation);
                        swords.transform.localRotation = swordRot;
                    }
                }
                
            }
        }

        public void AssignRifles()
        {
            for (int i = 0; i < InventoryMain.Instance.inventoryRange.Count; i++)
            {
                if(InventoryMain.Instance.inventoryRange[i] != null)
                {   
                    int a = allRifle[i].transform.childCount;
                    if(a != 1)
                    {
                        GameObject rifle = Instantiate(InventoryMain.Instance.inventoryRange[i].rangeWeaponObject);
                        rifle.transform.SetParent(allRifle[i].transform);
                        rifle.transform.localPosition = InventoryMain.Instance.inventoryRange[i].position;
                        Quaternion rifleRot = Quaternion.Euler(InventoryMain.Instance.inventoryRange[i].rotation);
                        rifle.transform.localRotation = rifleRot;
                    }
                }
            }
            
        }

        public void DisableWeapon(WeaponState weaponState)
        {
            switch(weaponState)
            {
                case WeaponState.box:
                    rightGlovesHolder.gameObject.SetActive(true);
                    leftGlovesHolder.gameObject.SetActive(true);
                    swordHolder.gameObject.SetActive(false);
                    rifleHolder.gameObject.SetActive(false);
                        break;
                case WeaponState.swords:
                    rightGlovesHolder.gameObject.SetActive(false);
                    leftGlovesHolder.gameObject.SetActive(false);
                    swordHolder.gameObject.SetActive(true);
                    rifleHolder.gameObject.SetActive(false);
                        break;
                case WeaponState.rifle:
                    rightGlovesHolder.gameObject.SetActive(false);
                    leftGlovesHolder.gameObject.SetActive(false);
                    swordHolder.gameObject.SetActive(false);
                    rifleHolder.gameObject.SetActive(true);
                        break;
            }
        }  

        public void InstantiateCurrentRifle(){
            
            for (int i = 0; i < InventoryMain.Instance.inventoryRange.Count; i++){
                if(InventoryMain.Instance.inventoryRange[i] != null && InventoryMain.Instance.inventoryRange[i].currentUsed){
                    allRifle[i].SetActive(true);
                }else
                    allRifle[i].SetActive(false);  
            }
        }

        public void Shooting()
        {   
            nextShoot -= Time.deltaTime;

            if(pAttack.shoot && nextShoot <= 0)
            {
                nextShoot = nextShootTemp;
                InventoryMain.Instance.oP.SpawProjectile(bulletTag, projectileSpawner.transform.position, projectileSpawner.transform.rotation);
            }
        } 
    }
}   

