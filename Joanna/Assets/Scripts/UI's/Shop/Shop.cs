using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

namespace rpg{

    public class Shop : MonoBehaviour
    {
        public GameObject shop, questNotactive, tabs, close;
        public GameObject control, weaponTabs, inventoryButton;
        public GameObject itemContainer, itemButtonGO, itemChestContainer, consumableChestButtonGO;
        public TextMeshProUGUI buyCountText, goldText;
        public int buyCountNum;
        public Consumables consumables;

        public void Awake(){
            CloseAll();
            buyCountNum = 1;
            buyCountText.text = buyCountNum.ToString();
            goldText.text = InventoryMain.Instance.gold.ToString();
        }

        public void PopulateItemsInInventory(){
            for (int i = 0; i < InventoryMain.Instance.consumablesInventory.Count; i++){
                GameObject go = Instantiate(consumableChestButtonGO);
                ConsumablesChestButton item = go.GetComponent<ConsumablesChestButton>();
                item.consumables = InventoryMain.Instance.consumablesInventory[i];
                item.itemName.text = InventoryMain.Instance.consumablesInventory[i].itemName;
                item.itemInfo = InventoryMain.Instance.consumablesInventory[i].itemInfo;
                go.transform.SetParent(itemContainer.transform, false);
            }
        }

        public void DestroyAllItemsInInventory(){
            int n = itemContainer.transform.childCount;

            for (int i = 0; i < n; i++){
                Destroy(itemContainer.transform.GetChild(i).gameObject);
            }
        }

        public void PopulateItemsChest(){
            for (int i = 0; i < InventoryMain.Instance.allConsumables.Count; i++){
                GameObject go = Instantiate(itemButtonGO);
                ItemShopButton item = go.GetComponent<ItemShopButton>();
                item.consumables = InventoryMain.Instance.allConsumables[i];
                item.itemName.text = InventoryMain.Instance.allConsumables[i].itemName;
                item.itemInfo = InventoryMain.Instance.allConsumables[i].itemInfo;
                go.transform.SetParent(itemChestContainer.transform, false);
            }
        }

        public void DestroyAllItemsInChest(){
            int n = itemChestContainer.transform.childCount;

            for (int i = 0; i < n; i++){
                Destroy(itemChestContainer.transform.GetChild(i).gameObject);
            }
        }
        ///Buying Logic
        public void AddCount(){
            if(consumables == null)
                return;
            buyCountNum++;
            buyCountText.text = buyCountNum.ToString();
        }

        public void SubtractCount(){
            if(consumables == null)
                return;
            if(buyCountNum >1)
                buyCountNum--;
            buyCountText.text = buyCountNum.ToString();
        }

        public void Buy(){
            if(consumables != null)
                if(!InventoryMain.Instance.consumablesInventory.Contains(consumables)){
                    consumables.itemCount += buyCountNum;
                    InventoryMain.Instance.consumablesInventory.Add(consumables);
                }
                else
                    consumables.itemCount += buyCountNum;
            DestroyAllItemsInInventory();
            PopulateItemsInInventory();
            goldText.text = (InventoryMain.Instance.gold - (consumables.itemCost * buyCountNum)).ToString();
            consumables = null;
            buyCountNum = 1;
            buyCountText.text = buyCountNum.ToString();
        }
    
        ///Opening Closing Shop
        public void OpenShop(){
            consumables = null;
            buyCountNum = 1;
            buyCountText.text = buyCountNum.ToString();
            DestroyAllItemsInChest();
            tabs.SetActive(true);
            shop.SetActive(true);
            PopulateItemsChest();
            questNotactive.SetActive(false);
        }
        
        public void OpenQuestNotActive(){ 
            consumables = null;  
            buyCountNum = 1;
            buyCountText.text = buyCountNum.ToString();
            DestroyAllItemsInChest();
            tabs.SetActive(true);
            shop.SetActive(false);
            PopulateItemsChest();
            questNotactive.SetActive(true);
        }

        public void CloseAll(){
            consumables = null;
            buyCountNum = 1;
            buyCountText.text = buyCountNum.ToString();
            DestroyAllItemsInChest();
            control.SetActive(true);
            weaponTabs.SetActive(true);
            inventoryButton.SetActive(true);
            tabs.SetActive(false);
            shop.SetActive(false);
            questNotactive.SetActive(false);
            close.SetActive(false);
        }
    }
}

