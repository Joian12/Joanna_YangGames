using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace rpg{
    public class ItemShopButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler{
        
        public TextMeshProUGUI itemName;
        public TextMeshProUGUI textInfo;
        public string itemInfo;
        public GameObject mainShop;
        public Consumables consumables;
        public Shop shop;
        public RawImage rawImage;

        private void Start(){
            mainShop = gameObject.transform.parent.parent.parent.parent.gameObject;
            textInfo = mainShop.transform.GetChild(0).gameObject.GetComponentInChildren<TextMeshProUGUI>();
            shop = gameObject.transform.parent.parent.parent.parent.parent.gameObject.GetComponent<Shop>();
            rawImage = GetComponent<RawImage>();
        }

        public void OnPointerEnter(PointerEventData eventData){
            textInfo.text = itemInfo;
        }

        public void OnPointerExit(PointerEventData eventData){
            textInfo.text = " ";
        }
        
        public void AddToCart(){
            consumables.isGonnaBuy = true;
            shop.consumables = consumables;
            foreach (Consumables item in InventoryMain.Instance.allConsumables){
                if(consumables.itemName != item.itemName)
                    item.isGonnaBuy = false;
            }
            ChangeColor();
        }

        private void ChangeColor(){
            int num = shop.itemChestContainer.transform.childCount;
            for (int i = 0; i < num; i++){
                ItemShopButton go = shop.itemChestContainer.transform.GetChild(i).gameObject.GetComponent<ItemShopButton>();
                
                go.rawImage.color = (go.consumables.isGonnaBuy) ? go.consumables.selectedColor : go.consumables.notSelectedColor;
            }
        }
    }
}

