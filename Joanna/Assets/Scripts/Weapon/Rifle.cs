using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpg
{
    public class Rifle : MonoBehaviour, I_Interact
    {
        public RangeWeaponSC rwSC;

        public void Interact()
        {
            gameObject.SetActive(false);
        }

        public void DeInteract()
        {

        }

        public void OnDisable()
        {
            //InventoryMain.Instance.AddToRifle(rwSC);
        }
    }
}

