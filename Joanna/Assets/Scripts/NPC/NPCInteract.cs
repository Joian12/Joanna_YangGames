using UnityEngine;

namespace rpg{
    public class NPCInteract : MonoBehaviour, I_Interact{   
        public NPCNames npcnNames;
        public GameObject canvas, questUI, questFromNPC, scrollToBeAccepted;

        public GameObject controls, weaponToggles ,exclamation , question;
        private GameObject shop, exit, tabs;
        public Quest_UI questUi_;
        public Shop shop_;

        private void Start() {
            canvas = GameObject.FindGameObjectWithTag("Canvas").gameObject;
            questUI = canvas.transform.GetChild(6).gameObject;
            controls = canvas.transform.GetChild(0).gameObject;
            weaponToggles = canvas.transform.GetChild(1).gameObject;
            scrollToBeAccepted = questUI.transform.GetChild(1).gameObject;
            exit = canvas.transform.GetChild(7).GetChild(0).gameObject;
            tabs = canvas.transform.GetChild(7).GetChild(1).gameObject;
            shop = canvas.transform.GetChild(7).GetChild(2).gameObject;
            shop_ = canvas.transform.GetChild(7).GetComponent<Shop>();
            questUi_ = questUI.GetComponent<Quest_UI>();
        }

        public void Interact(){   
               switch (npcnNames)
               {
                    case NPCNames.ShopKeeper:
                        shop_.DestroyAllItemsInChest();
                        shop_.PopulateItemsChest();
                        exit.SetActive(true);
                        tabs.SetActive(true);
                        shop.SetActive(true);
                        QuestInteract();
                        break;
                    case NPCNames.GrandAdvisor:
                        QuestInteract();
                        break;
                    case NPCNames.TownMayor:
                        QuestInteract();
                        break;
                    case NPCNames.FlyGirlCollector:
                        QuestInteract();
                        break;
               }
        }

        public void DeInteract(){

        }

        private void QuestInteract(){
            QuestManager.instance.currentNPC = this;
            questUi_.quest_NotActive.npcnNames = npcnNames;
            questUi_.quest_NotActive.ResetFromNPC();
            questUi_.quest_NotActive.QuestFromNPC();
            controls.SetActive(false);
            weaponToggles.SetActive(false);
            questUi_.ToBeAccepted.SetActive(true);
            questUi_.inventoryTab.SetActive(false); 
        }
    }

    public enum NPCNames{
        GrandAdvisor, TownMayor, ShopKeeper, FlyGirlCollector
    }
}


