using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

namespace rpg
{   
    public enum Tabs
    {
        gloveTabs,
        swordTabs, 
        rangeTabs
    }

    public class InventoryChestButtons : MonoBehaviour
    {   
        public Tabs tabs;
        public GameObject weapons, armor, scraps;
        public GameObject gloves, swords, rifles;
        public GameObject gloveTab, swordTab, rifleTab;
        public GloveHolder gloveHolder;
        public SwordsHolder swordHolder;
        public RifleHolder rifleHolder;
        public InventoryUIButton inventoryUIButton;
        public WeaponHolder weaponHolder;
        public ObjectPooler_ objectPooler;

        public TextMeshProUGUI[] inventories;
        public GameObject inventoryChestUI, control, weaponToggles;
        PlayerUI playerUI;

        private void Awake()
        {   
            InventorySlot<MeleeWeaponsSc>(InventoryMain.Instance.inventoryGloves);
            
            playerUI = GetComponent<PlayerUI>();
            objectPooler = GameObject.FindGameObjectWithTag("Pooler").gameObject.GetComponent<ObjectPooler_>();
            
        }

        private void Update() {
            if(weaponHolder == null)
            {   
                weaponHolder = GetComponent<PlayerUI>().weaponHolder;
                weaponHolder.InstantiateCurrentRifle();
                InitiliazeChestInventory();
            }
                
        }
        public void InitiliazeChestInventory(){
        
                tabs = Tabs.rangeTabs;
                AddButtonItem();
                tabs = Tabs.swordTabs;
                AddButtonItem();
                tabs = Tabs.gloveTabs;
                AddButtonItem();
        }

        public void AddButtonItem()
        {   
            switch (tabs)
            {   
                case Tabs.gloveTabs:
                    GloveTabs();
                    break;
                case Tabs.swordTabs:
                    SwordTabs();
                    break;
                case Tabs.rangeTabs:
                    RangeTabs();
                    break;
            }
            
            inventoryUIButton.Assign();
        }

        public void GloveTabs(){
            AddingToInventoryGloves(InventoryMain.Instance.allGloves, InventoryMain.Instance.inventoryGloves);
            InventorySlot<MeleeWeaponsSc>(InventoryMain.Instance.inventoryGloves);
            weaponHolder.AssignGloves();
        }
        public void SwordTabs(){
            AddingToInventorySwords(InventoryMain.Instance.allSwords, InventoryMain.Instance.inventorySwords);
            InventorySlot<MeleeWeaponsSc>(InventoryMain.Instance.inventorySwords);
            weaponHolder.AssignSwords();
        }
        public void RangeTabs(){
            AddingToInventoryRange(InventoryMain.Instance.allRange, InventoryMain.Instance.inventoryRange);
            InventorySlot<RangeWeaponSC>(InventoryMain.Instance.inventoryRange);
            weaponHolder.AssignRifles();
            objectPooler.SettingProjectilePool();
            inventoryUIButton.CheckActiveRifle(weaponHolder);
            weaponHolder.InstantiateCurrentRifle();
        }

        public void AddingToInventoryGloves(List<MeleeWeaponsSc> glovesList, List<MeleeWeaponsSc> inventoryGloves)
        {   
            for (int i = 0; i < glovesList.Count; i++)
            {
                if(glovesList[i].addedToInventory == true)
                    for (int j = 0; j < inventoryGloves.Count; j++)
                    {
                        if(inventoryGloves[j] == null && !inventoryGloves.Contains(glovesList[i]))
                            inventoryGloves[j] = glovesList[i];
                    }
            }

            glovesList.RemoveAll(x => x.addedToInventory == true);

            gloveHolder.Destroy();
            gloveHolder.Reset();
        }

        public void AddingToInventorySwords(List<MeleeWeaponsSc> swordList, List<MeleeWeaponsSc> inventorySwords)
        {   
            for (int i = 0; i < swordList.Count; i++)
            {
                if(swordList[i].addedToInventory == true)
                    for (int j = 0; j < inventorySwords.Count; j++)
                    {
                        if(inventorySwords[j] == null && !inventorySwords.Contains(swordList[i]))
                            inventorySwords[j] = swordList[i];
                    }
            }

            swordList.RemoveAll(x => x.addedToInventory == true);

            swordHolder.Destroy();
            swordHolder.Reset();
        }

        public void AddingToInventoryRange(List<RangeWeaponSC> rangeList, List<RangeWeaponSC> inventoryRange)
        {   
            for (int i = 0; i < rangeList.Count; i++)
            {
                if(rangeList[i].addedToInventory)
                    for (int j = 0; j < inventoryRange.Count; j++)
                    {
                        if(inventoryRange[j] == null && !inventoryRange.Contains(rangeList[i]))
                        {   
                            if(inventoryRange.Any(i => i == null))
                            {
                                inventoryRange[j] = rangeList[i];
                                inventoryRange[0].isActive = true;
                            }
                            else
                                inventoryRange[j] = rangeList[i];
                            
                        }
                    }
            }

            rangeList.RemoveAll(x => x.addedToInventory == true);

            rifleHolder.Destroy();
            rifleHolder.Reset();
        }
        
#region 
        public void OpenWeapon()
        {   
            OpenGloves();
            InventorySlot<MeleeWeaponsSc>(InventoryMain.Instance.inventoryGloves);
            WeaponTabs(true);
            weapons.SetActive(true);
            armor.SetActive(false);
            scraps.SetActive(false);
        }

        public void OpenArmor()
        {
            WeaponTabs(false);
            weapons.SetActive(false);
            armor.SetActive(true);
            scraps.SetActive(false);
        }

        public void OpenScraps()
        {
            WeaponTabs(false);
            weapons.SetActive(false);
            armor.SetActive(false);
            scraps.SetActive(true);
        }

        public void OpenGloves()
        {   
            tabs = Tabs.gloveTabs;
            InventorySlot<MeleeWeaponsSc>(InventoryMain.Instance.inventoryGloves);
            gloves.SetActive(true);
            swords.SetActive(false);
            rifles.SetActive(false);
        }

        public void OpenSwords()
        {   
            tabs = Tabs.swordTabs;
            InventorySlot<MeleeWeaponsSc>(InventoryMain.Instance.inventorySwords);
            gloves.SetActive(false);
            swords.SetActive(true);
            rifles.SetActive(false);
        }

        public void OpenRifles()
        {   
            tabs = Tabs.rangeTabs;
            InventorySlot<RangeWeaponSC>(InventoryMain.Instance.inventoryRange);
            gloves.SetActive(false);
            swords.SetActive(false);
            rifles.SetActive(true);
        }

        public void WeaponTabs(bool bool_)
        {
            gloveTab.SetActive(bool_);
            swordTab.SetActive(bool_);
            rifleTab.SetActive(bool_);
        }

        public void CloseInventory()
        {   
            inventoryUIButton.questTab.SetActive(true);
            inventoryUIButton.inventoryTab.SetActive(true);
            playerUI.playerAttack_Interact.pressingRight = false;
            control.SetActive(true);
            weaponToggles.SetActive(true);
            inventoryChestUI.SetActive(false);
            OpenWeapon();
        }
#endregion

        public void InventorySlot<T>(List<T> inventoryList)
        {
            switch (tabs)
            {
                case Tabs.gloveTabs: case Tabs.swordTabs:
                    List<MeleeWeaponsSc> tempList = inventoryList.Cast<MeleeWeaponsSc>().ToList();
                    for (int i = 0; i < tempList.Count; i++)
                    {   
                        if(tempList[i] != null)
                            inventories[i].text = tempList[i].meleeWeaponName;
                        else
                            inventories[i].text = "Empty"; 
                    }
                    break;
                case Tabs.rangeTabs:
                    List<RangeWeaponSC> rangeList = inventoryList.Cast<RangeWeaponSC>().ToList();
                    for (int i = 0; i < rangeList.Count; i++)
                    {   
                        if(rangeList[i] != null)
                            inventories[i].text = rangeList[i].rangeWeaponName;
                        else
                            inventories[i].text = "Empty"; 
                    }
                    break;
            }
        }

        public void RemoveItem_1()
        {
            RemoveItemHelper(0);
            
        }

        public void RemoveItem_2()
        {
            RemoveItemHelper(1);
        }

        public void RemoveItem_3()
        {
            RemoveItemHelper(2);
        }

        private void RemoveItemHelper(int num)
        {   
            
            switch (tabs)
            {
                case Tabs.gloveTabs:
                    if(InventoryMain.Instance.inventoryGloves[num] == null) 
                        return;
                    
                    InventoryMain.Instance.inventoryGloves[num].addedToInventory = false;
                    InventoryMain.Instance.allGloves.Add(InventoryMain.Instance.inventoryGloves[num]);
                    InventoryMain.Instance.inventoryGloves[num] = null;
                    InventorySlot<MeleeWeaponsSc>(InventoryMain.Instance.inventoryGloves);
                    if(weaponHolder.allLeftGloves[num].transform.GetChild(0).gameObject != null)
                        Destroy(weaponHolder.allLeftGloves[num].transform.GetChild(0).gameObject);
                    if(weaponHolder.allRightGloves[num].transform.GetChild(0).gameObject != null)
                        Destroy(weaponHolder.allRightGloves[num].transform.GetChild(0).gameObject);
                    InventoryMain.Instance.gloveInt += 1;
                    gloveHolder.Destroy();
                    gloveHolder.Reset();
                    inventoryUIButton.buttonGloves[num].Remove();
                    break;
                case Tabs.swordTabs:
                    if(InventoryMain.Instance.inventorySwords[num] == null) 
                        return;
                    
                    InventoryMain.Instance.inventorySwords[num].addedToInventory = false;
                    InventoryMain.Instance.allSwords.Add(InventoryMain.Instance.inventorySwords[num]);
                    InventoryMain.Instance.inventorySwords[num] = null;
                    InventorySlot<MeleeWeaponsSc>(InventoryMain.Instance.inventorySwords);
                    if(weaponHolder.allSwords[num].transform.GetChild(0).gameObject != null)
                        Destroy(weaponHolder.allSwords[num].transform.GetChild(0).gameObject);
                    InventoryMain.Instance.swordInt += 1;
                    swordHolder.Destroy();
                    swordHolder.Reset();
                    inventoryUIButton.buttonSwords[num].Remove();
                    break;
                case Tabs.rangeTabs:

                    if(InventoryMain.Instance.inventoryRange[num] != null) 
                    {
                        objectPooler.allPooledObjects.Remove(InventoryMain.Instance.inventoryRange[num].rangeWeaponName);
  
                        for (int i = 0; i < InventoryMain.Instance.inventoryRange.Count; i++)
                        {
                            if(InventoryMain.Instance.inventoryRange[i] != null && InventoryMain.Instance.inventoryRange[i].isActive)
                            {
                                weaponHolder.nextShoot = InventoryMain.Instance.inventoryRange[i].nextShoot;
                                weaponHolder.nextShootTemp = InventoryMain.Instance.inventoryRange[i].nextShoot;
                                weaponHolder.bulletTag = InventoryMain.Instance.inventoryRange[i].rangeWeaponName;
                            }
                        }
                        
                        InventoryMain.Instance.inventoryRange[num].addedToInventory = false;
                        InventoryMain.Instance.inventoryRange[num].isActive = false;
                        InventoryMain.Instance.inventoryRange[num].currentUsed = false;
                        InventoryMain.Instance.allRange.Add(InventoryMain.Instance.inventoryRange[num]);
                        InventoryMain.Instance.inventoryRange[num] = null;

                        InventorySlot<RangeWeaponSC>(InventoryMain.Instance.inventoryRange);
                        Debug.Log(weaponHolder.allRifle[num].name);
                        if(weaponHolder.allRifle[num].transform.GetChild(0).gameObject != null)
                            Destroy(weaponHolder.allRifle[num].transform.GetChild(0).gameObject);
                        
                        objectPooler.projectileObj[num].name = ""; 
                        objectPooler.projectileObj[num].objectToPool = null;
                        objectPooler.projectileObj[num].size = 0;

                        int howMany = objectPooler.projectileParent[num].transform.childCount;

                        for (int i = 0; i < howMany; i++)
                        {
                            Destroy(objectPooler.projectileParent[num].transform.GetChild(i).gameObject);
                        }

                        InventoryMain.Instance.rangeInt += 1;
                        rifleHolder.Destroy();
                        rifleHolder.Reset();
                        inventoryUIButton.buttonRange[num].Remove();
                    }
                    break;
            }
        }
    }
}

