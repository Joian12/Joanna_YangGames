using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

namespace rpg{
    [CreateAssetMenu(fileName = "Consumables", menuName = "Items", order = 2)]
    public class Consumables : ScriptableObject{
        public string itemName;
        public string itemInfo;
        public int itemCount, itemCost;
        public bool isGonnaBuy;
        public Color selectedColor;
        public Color notSelectedColor;
        public TownEnum townName;
    }

}
