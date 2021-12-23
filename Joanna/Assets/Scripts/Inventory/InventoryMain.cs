using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpg
{
    public class InventoryMain : MonoBehaviour
    {   
        public static InventoryMain Instance;
        public List<MeleeWeaponsSc> allGloves = new List<MeleeWeaponsSc>();
        public List<MeleeWeaponsSc> allSwords = new List<MeleeWeaponsSc>();
        public List<RangeWeaponSC> allRange = new List<RangeWeaponSC>();

        public int gloveInt;
        public int swordInt;
        public int rangeInt;
        public List<MeleeWeaponsSc> inventoryGloves = new List<MeleeWeaponsSc>();
        public List<MeleeWeaponsSc> inventorySwords = new List<MeleeWeaponsSc>();
        public List<RangeWeaponSC> inventoryRange = new List<RangeWeaponSC>();

        /////Consumables
        public List<Consumables> allConsumables = new List<Consumables>();
        public List<Consumables> consumablesInventory = new List<Consumables>();

        ////Player Inventory 
        public int gold;

        public ObjectPooler_ oP;
        
        public void Start() 
        {
            oP = GameObject.FindGameObjectWithTag("Pooler").gameObject.GetComponent<ObjectPooler_>();
        }

        private void Awake()
        {   
            Instance = this;  
        }

        private void AddToInvetoryGloves(MeleeWeaponsSc gloves)
        {   
            if(inventoryGloves.Count != 3)
                inventoryGloves.Add(gloves);
        }

        public void AddToInventorySwords(MeleeWeaponsSc swords)
        {   
            if(inventorySwords.Count != 3)
                inventorySwords.Add(swords);
        }

        public void AddToInventoryRange(RangeWeaponSC range)
        {
            if(inventoryRange.Count != 3)
                inventoryRange.Add(range);
        }

        public void AddToGloves(MeleeWeaponsSc gloves)
        {   
            allGloves.Add(gloves);
        }

        public void AddToSwords(MeleeWeaponsSc swords)
        {
            allSwords.Add(swords);
        }

        public void AddToRifle(RangeWeaponSC rifle)
        {
            allRange.Add(rifle);
        }
    }
}
