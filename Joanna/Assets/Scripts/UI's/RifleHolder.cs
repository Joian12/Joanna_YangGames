using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace rpg
{
    public class RifleHolder : MonoBehaviour
    {
        public Transform rifleHolder;
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
            for (int i = 0; i < InventoryMain.Instance.allRange.Count; i++)
            {
                GameObject go = Instantiate(weaponItem);
                WeaponItem wi = go.GetComponent<WeaponItem>();
                TextMeshProUGUI text = go.GetComponentInChildren<TextMeshProUGUI>();
                wi.range = InventoryMain.Instance.allRange[i];
                text.text = InventoryMain.Instance.allRange[i].rangeWeaponName;
                go.transform.SetParent(rifleHolder, false);
            }
        }
    }
}


