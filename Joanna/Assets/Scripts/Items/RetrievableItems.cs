using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace rpg{

    public class RetrievableItems : MonoBehaviour, I_Interact{
        public string itemName;
        public GameObject canvas, questUi, retrievePrompt, controls, weaponToggles;
        public TextMeshProUGUI message;
        private Quest_UI quest_UI;

        private void Start() {
            canvas = GameObject.FindGameObjectWithTag("Canvas").gameObject;
            controls = canvas.transform.GetChild(0).gameObject;
            weaponToggles = canvas.transform.GetChild(1).gameObject;
            questUi = canvas.transform.GetChild(6).gameObject;
            quest_UI = questUi.GetComponent<Quest_UI>();
            retrievePrompt = questUi.transform.GetChild(5).gameObject;
            message = retrievePrompt.gameObject.GetComponentInChildren<TextMeshProUGUI>();
        }

        public void Interact(){
            CheckRetrieveQuestList();
        }

        public void DeInteract(){

        }

        public void CheckRetrieveQuestList(){
            foreach (Quest_Retrieve item in QuestManager.instance.allQuestRetrieve){
                if(itemName == item.itemName && item.alreadAdded){
                    message.text = item.message;
                    quest_UI.retrieve = item;
                    retrievePrompt.SetActive(true);
                    controls.SetActive(false);
                    weaponToggles.SetActive(false);
                }
            }
        }
    }
}


