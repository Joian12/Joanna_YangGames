using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace rpg
{
    public class GloveHolder : MonoBehaviour
    {      
        public Transform gloveHolder;
        public GameObject weaponItem;
        private void OnEnable()
        {
            Reset();
        }

        private void OnDisable()
        {   
            Destroy();
        }

        public void Destroy()
        {
            int num = transform.childCount;
            for (int i = 0; i < num; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }

        public void Reset()
        {   
            Destroy();
            for (int i = 0; i < InventoryMain.Instance.allGloves.Count; i++)
            {
                GameObject go = Instantiate(weaponItem);
                WeaponItem wi = go.GetComponent<WeaponItem>();
                TextMeshProUGUI text = go.GetComponentInChildren<TextMeshProUGUI>();
                wi.melee = InventoryMain.Instance.allGloves[i];
                text.text = InventoryMain.Instance.allGloves[i].meleeWeaponName;
                go.transform.SetParent(gloveHolder, false);
            }
        }
    }   
}


