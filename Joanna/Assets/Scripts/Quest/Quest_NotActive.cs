using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace rpg{
    public class Quest_NotActive : MonoBehaviour{   
        public GameObject quest;
        public NPCNames npcnNames;
        public GameObject mainQuestToBeAcceptedPanel;
        public GameObject sideQuestToBeAcceptedPanel;
        public Quest_Kill mainKill;
        public Quest_Retrieve mainRetrieve;
        public Quest_Travel mainTravel;
        public string nextQuest;

        public void CheckNextMainQuest(){
            Debug.Log(nextQuest);
            foreach (Quest_Kill item in QuestManager.instance.allQuestKill){
                if(nextQuest == item.questName)
                    item.mainActive = true;
            }   

            foreach (Quest_Retrieve item in QuestManager.instance.allQuestRetrieve){
                if(nextQuest == item.questName)
                    item.mainActive = true;
            }

            foreach (Quest_Travel item in QuestManager.instance.allQuestTravel){
                if(nextQuest == item.questName)
                    item.mainActive = true;
            }
        }

        public void RemovedFromActiveList(){
            foreach (Quest_Kill item in QuestManager.instance.allQuestKill){
                if(item.finished)
                    item.alreadAdded = false;
            }

            foreach (Quest_Retrieve item in QuestManager.instance.allQuestRetrieve){
                if(item.finished)
                    item.alreadAdded = false;
            }

            foreach (Quest_Travel item in QuestManager.instance.allQuestTravel){
                if(item.finished)
                    item.alreadAdded = false;
            }
        }

        public void QuestFromNPC(){   
            RemovedFromActiveList();
            QuestKill();
            QuestRetrieve();
            QuestTravel();
            ChangeStateQuestUI();
            ChangeStateActiveQuestUI();
        }

        public void QuestKill(){
            foreach (Quest_Kill item in QuestManager.instance.allQuestKill){
                if(!item.alreadAdded && item.npcnNames == npcnNames && !item.done){
                    GameObject go = Instantiate(quest);
                    QuestButton button = go.GetComponent<QuestButton>();
                    button.kill = item;
                    TextMeshProUGUI text = go.GetComponentInChildren<TextMeshProUGUI>();
                    text.text = item.questName;
                    if(item.questType == QuestType.MainQuest){   
                        if(item.mainActive)
                            go.transform.SetParent(mainQuestToBeAcceptedPanel.transform,false);
                    }
                    else
                        go.transform.SetParent(sideQuestToBeAcceptedPanel.transform,false);
                }
            }
        }

        public void QuestRetrieve(){   
            foreach (Quest_Retrieve item in QuestManager.instance.allQuestRetrieve){
                if(!item.alreadAdded && item.npcnNames == npcnNames && !item.done){
                    GameObject go = Instantiate(quest);
                    QuestButton button = go.GetComponent<QuestButton>();
                    button.isActive = false;
                    button.retrieve = item;
                    TextMeshProUGUI text = go.GetComponentInChildren<TextMeshProUGUI>();
                    text.text = item.questName;
                    if(item.questType == QuestType.MainQuest){   
                        if(item.mainActive)
                            go.transform.SetParent(mainQuestToBeAcceptedPanel.transform,false);
                    }
                    else
                        go.transform.SetParent(sideQuestToBeAcceptedPanel.transform,false);
                }
            }
        }

        public void QuestTravel(){
            foreach (Quest_Travel item in QuestManager.instance.allQuestTravel){
                if(!item.alreadAdded && item.npcnNames == npcnNames && !item.done){
                    GameObject go = Instantiate(quest);
                    QuestButton button = go.GetComponent<QuestButton>();
                    button.isActive = false;
                    button.travel = item;
                    TextMeshProUGUI text = go.GetComponentInChildren<TextMeshProUGUI>();
                    text.text = item.questName;
                    if(item.questType == QuestType.MainQuest){   
                        if(item.mainActive)
                            go.transform.SetParent(mainQuestToBeAcceptedPanel.transform,false);
                    }
                    else
                        go.transform.SetParent(sideQuestToBeAcceptedPanel.transform,false);
                }
            }
        }

        public void QuestTravelLocation(string destinationName){   
            foreach (Quest_Travel item in QuestManager.instance.allQuestTravel){
                if(item.alreadAdded && item.npcnNames == npcnNames && !item.done && item.finished && destinationName == item.destination){
                    GameObject go = Instantiate(quest);
                    QuestButton button = go.GetComponent<QuestButton>();
                    button.isActive = false;
                    button.travel = item;
                    TextMeshProUGUI text = go.GetComponentInChildren<TextMeshProUGUI>();
                    text.text = item.questName;
                    if(item.questType == QuestType.MainQuest){   
                        if(item.mainActive)
                            go.transform.SetParent(mainQuestToBeAcceptedPanel.transform,false);
                    }
                    else
                        go.transform.SetParent(sideQuestToBeAcceptedPanel.transform,false);
                }
            }
        }

        public void ResetFromNPC(){
            int num = mainQuestToBeAcceptedPanel.transform.childCount;

            for (int i = 0; i < num; i++){
                Destroy(mainQuestToBeAcceptedPanel.transform.GetChild(i).gameObject);
            }

            int num1 = sideQuestToBeAcceptedPanel.transform.childCount;
    
            for (int i = 0; i < num1; i++){
                Destroy(sideQuestToBeAcceptedPanel.transform.GetChild(i).gameObject);
            }
        }

        public void ChangeStateQuestUI(){
            if(sideQuestToBeAcceptedPanel.transform.childCount != 0)
            {
                int num1 = sideQuestToBeAcceptedPanel.transform.childCount;
    
                for (int i = 0; i < num1; i++)
                {   
                    Debug.Log("Loop 1");
                    GameObject go = sideQuestToBeAcceptedPanel.transform.GetChild(i).gameObject;
                    QuestButton goQB = go.GetComponent<QuestButton>();
                    goQB.ButtonState();
                }
            }
        }

        public void ChangeStateActiveQuestUI()
        {
            if(mainQuestToBeAcceptedPanel.transform.childCount != 0)
            {
                int num2 = mainQuestToBeAcceptedPanel.transform.childCount;
    
                for (int i = 0; i < num2; i++)
                {   
                    GameObject go = mainQuestToBeAcceptedPanel.transform.GetChild(i).gameObject;
                    QuestButton goQB = go.GetComponent<QuestButton>();
                    goQB.ButtonState();
                }
            }
        }

    }
}

