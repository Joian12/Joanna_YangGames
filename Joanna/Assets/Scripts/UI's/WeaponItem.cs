using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

namespace rpg
{
    public class WeaponItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        public GameObject textView;
        public GameObject check;
        public MeleeWeaponsSc melee;
        public RangeWeaponSC range;
        public TextMeshProUGUI text;
        public int gloveInt, swordInt, rangeInt;
        public bool check_;

        private void Awake() 
        {   
            check_ = false;    
        }
        private void Update() 
        {   
            if(textView == null)
                textView = transform.parent.gameObject.transform.parent.gameObject.transform.GetChild(3).gameObject;    

            if(text == null)
                text = textView.GetComponentInChildren<TextMeshProUGUI>();
        }
        
        public void OnPointerClick(PointerEventData pointerEventData)
        {   
            if(melee != null)
            {   
                switch (melee.meleeType)
                {
                    case MeleeType.boxingGloves:
            
                        if(melee.addedToInventory == false) 
                        {   
                            if(InventoryMain.Instance.gloveInt == 0)
                                return;
        
                            InventoryMain.Instance.gloveInt -= 1;
                            melee.addedToInventory = true; 
                        }
                        else
                        {
                            melee.addedToInventory = false;
                            InventoryMain.Instance.gloveInt += 1;
                        }
                        check_ = melee.addedToInventory;
                        break;
                    case MeleeType.swords:

                        if(melee.addedToInventory == false) 
                        {   
                            if(InventoryMain.Instance.swordInt == 0)
                                return;
        
                            InventoryMain.Instance.swordInt -= 1;
                            melee.addedToInventory = true; 
                        }
                        else
                        {
                            melee.addedToInventory = false;
                            InventoryMain.Instance.swordInt += 1;
                        }
                        check_ = melee.addedToInventory;
                        break;
                }
            }
                
            
            if(range != null)
            {   
                if(range.addedToInventory == false) 
                {   
                    if(InventoryMain.Instance.rangeInt == 0)
                        return;
        
                    InventoryMain.Instance.rangeInt -= 1;
                    range.addedToInventory = true; 
                }
                else
                {
                    range.addedToInventory = false;
                    InventoryMain.Instance.rangeInt += 1;
                }
                check_ = range.addedToInventory;
            }
            
            check.SetActive(check_);
        }


        public void OnPointerEnter(PointerEventData eventData)
        {   
            if(melee != null)  
            {
                MeleeStats();
            }

            if(range != null)
            {
                RangeStats();
            }
        }

        public void MeleeStats()
        {
            text.text = melee.meleeWeaponName;
        }

        public void RangeStats()
        {
            text.text = range.rangeWeaponName;
        }

        public void OnPointerExit(PointerEventData eventData)
        {   
            text.text = " ";
        }
    }
}

