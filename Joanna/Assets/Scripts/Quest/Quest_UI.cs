using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace rpg
{
    public class Quest_UI : MonoBehaviour
    {
        public GameObject[] UiGo;
        public GameObject activeQuestPanel;
        public GameObject ToBeAccepted;
        public GameObject quest;

        public GameObject control;
        public GameObject weaponToggles;
        public GameObject closeButton, close2Button;
        public GameObject confirmation;
        public GameObject awardInfo;
        public Quest_Kill kill;
        public Quest_Retrieve retrieve;
        public Quest_Travel travel;
        public GameObject questTab;
        public GameObject inventoryTab ,retrievePrompt;

        //bools 
        private bool openQuest;
        public Quest_Active quest_Active;
        public Quest_NotActive quest_NotActive;

        private void Awake() {
            openQuest = false;  
            ToBeAccepted.SetActive(false);
            confirmation.SetActive(false);
            awardInfo.SetActive(false);
            retrievePrompt.SetActive(false);
            quest_Active.DestroyAndResetActive();
            quest_Active.PopulateActiveHelper(QuestManager.instance.allQuestKill, QuestManager.instance.allQuestRetrieve, QuestManager.instance.allQuestTravel);  
        }

        public void OpenQuestPanel(){
            closeButton.SetActive(true);
            questTab.SetActive(false);
            inventoryTab.SetActive(false);

            activeQuestPanel.SetActive(true);
            foreach (GameObject item in UiGo){
                item.SetActive(!openQuest);
            }                      
        }

        //Retrieve Yes OR NO
        public void RetrieveYes(){
            control.SetActive(true);
            retrieve.finished = true;
            Debug.Log(retrieve.itemName);
            quest_Active.ChangeStateQuestUI();
            quest_Active.ChangeStateActiveQuestUI();
            retrievePrompt.SetActive(false);
            weaponToggles.SetActive(true);
        }

        public void RetrieveNo(){
            control.SetActive(true);
            retrievePrompt.SetActive(false);
            weaponToggles.SetActive(true);
        }

        public void Close2(){   
            quest_NotActive.ResetFromNPC();
            ToBeAccepted.SetActive(false);
            control.SetActive(true);
            weaponToggles.SetActive(true);
            inventoryTab.SetActive(true);
        }
        
        public void CloseAwardInfo(){   
            foreach (Quest_Kill item in QuestManager.instance.allQuestKill){
                if(item.finished){
                    item.done = true;
                    if(item.mainActive){   
                        quest_NotActive.nextQuest = item.nextQuestName;
                        item.mainActive = false;
                    }
                }
            }

            foreach (Quest_Retrieve item in QuestManager.instance.allQuestRetrieve){
                if(item.finished){
                    item.done = true;
                    if(item.mainActive){   
                        quest_NotActive.nextQuest = item.nextQuestName;
                        item.mainActive = false;
                    }
                }
            }

            foreach (Quest_Travel item in QuestManager.instance.allQuestTravel){
                if(item.finished){
                    item.done = true;
                    if(item.mainActive){   
                        quest_NotActive.nextQuest = item.nextQuestName;
                        item.mainActive = false;
                    }
                }
            }
            
            quest_NotActive.CheckNextMainQuest();
            quest_NotActive.ResetFromNPC();
            quest_NotActive.QuestFromNPC();
            quest_Active.DestroyAndResetActive();
            quest_Active.PopulateActiveHelper(QuestManager.instance.allQuestKill, QuestManager.instance.allQuestRetrieve, QuestManager.instance.allQuestTravel);
            awardInfo.SetActive(false);
        }
        
        public void Yes(){    
            if(kill != null && kill.questType == QuestType.MainQuest && kill.mainActive)
                kill.alreadAdded = true;
            
            if(kill != null && kill.questType == QuestType.SideQuest && kill.active)
                kill.alreadAdded = true;

            if(retrieve != null && retrieve.questType == QuestType.MainQuest && retrieve.mainActive)
                retrieve.alreadAdded = true;
            
            if(retrieve != null && retrieve.questType == QuestType.SideQuest && retrieve.active)
                retrieve.alreadAdded = true;

            if(travel != null && travel.questType == QuestType.MainQuest && travel.mainActive){   
                travel.alreadAdded = true;
                QuestManager.instance.AddTravelQuest();
            }
                
            if(travel != null && travel.questType == QuestType.SideQuest && travel.active){
                travel.alreadAdded = true;
                QuestManager.instance.AddTravelQuest();
            }
                
            kill = null;
            retrieve = null;
            travel = null;
            quest_NotActive.ResetFromNPC();
            quest_NotActive.QuestFromNPC();
            quest_Active.DestroyAndResetActive();
            quest_Active.PopulateActiveHelper(QuestManager.instance.allQuestKill, QuestManager.instance.allQuestRetrieve, QuestManager.instance.allQuestTravel);
            confirmation.SetActive(false);
            ToBeAccepted.SetActive(true);
        }

        public void No(){
            confirmation.SetActive(false);
            if(kill != null){
                kill.active = false;
                kill = null;
            }
            
            if(retrieve != null){   
                retrieve.active = false;
                retrieve = null;
            }

            if(travel != null){   
                travel.active = false;
                travel = null;
            }
            ToBeAccepted.SetActive(true);
        }
    }
}


