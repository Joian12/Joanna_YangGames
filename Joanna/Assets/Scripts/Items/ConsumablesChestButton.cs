using UnityEngine;
using TMPro;

namespace rpg{
    public class ConsumablesChestButton : MonoBehaviour{  
        public string itemInfo;
        public TextMeshProUGUI itemName;
        public TextMeshProUGUI itemCount;
        public Consumables consumables;
        private void Start() {
            itemCount.text = consumables.itemCount.ToString();
        }
    }
}

