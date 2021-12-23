using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace rpg
{
    public class Quest_Active : MonoBehaviour
    {   
        public GameObject quest;
        public GameObject mainQuestHolder;
        public GameObject sideQuestHolder;

        public void PopulateActiveHelper(List<Quest_Kill> killList, List<Quest_Retrieve> retrieveList, List<Quest_Travel> travelLsit)
        {
            foreach (Quest_Kill item in killList)
            {
                if(item.alreadAdded)
                {   
                    GameObject go = Instantiate(quest);
                    TextMeshProUGUI goText = go.GetComponentInChildren<TextMeshProUGUI>();
                    QuestButton button = go.GetComponent<QuestButton>();
                    button.isActive = true;
                    button.kill = item;
                    goText.text = item.questName;
                    if(item.questType == QuestType.MainQuest)
                        go.transform.SetParent(mainQuestHolder.transform,false);
                    else
                        go.transform.SetParent(sideQuestHolder.transform,false);
                } 
            }

            foreach (Quest_Retrieve item in retrieveList)
            {   
                if(item.alreadAdded)
                {   
                    GameObject go = Instantiate(quest);
                    TextMeshProUGUI goText = go.GetComponentInChildren<TextMeshProUGUI>();
                    QuestButton button = go.GetComponent<QuestButton>();
                    button.isActive = true;
                    button.retrieve = item;
                    goText.text = item.questName;
                    if(item.questType == QuestType.MainQuest)
                        go.transform.SetParent(mainQuestHolder.transform,false);
                    else
                        go.transform.SetParent(sideQuestHolder.transform,false);
                }

            }

            foreach (Quest_Travel item in travelLsit)
            {   
               if(item.alreadAdded)
                {   
                    GameObject go = Instantiate(quest);
                    TextMeshProUGUI goText = go.GetComponentInChildren<TextMeshProUGUI>();
                    QuestButton button = go.GetComponent<QuestButton>();
                    button.isActive = true;
                    button.travel = item;
                    goText.text = item.questName;
                    if(item.questType == QuestType.MainQuest)
                            go.transform.SetParent(mainQuestHolder.transform,false);
                    else
                        go.transform.SetParent(sideQuestHolder.transform,false);
                }
            }
        }

        public void DestroyAndResetActive()
        {
            int main = mainQuestHolder.transform.childCount;

            for (int i = 0; i < main; i++)
            {
                Destroy(mainQuestHolder.transform.GetChild(i).gameObject);
            }

            int side = sideQuestHolder.transform.childCount;

            for (int i = 0; i < side; i++)
            {
                Destroy(sideQuestHolder.transform.GetChild(i).gameObject);
            }
        } 

         public void ChangeStateQuestUI(){
            if(sideQuestHolder.transform.childCount != 0)
            {
                int num1 = sideQuestHolder.transform.childCount;
    
                for (int i = 0; i < num1; i++)
                {   
                    Debug.Log("Loop 1");
                    GameObject go = sideQuestHolder.transform.GetChild(i).gameObject;
                    QuestButton goQB = go.GetComponent<QuestButton>();
                    goQB.ButtonState();
                }
            }
        }

        public void ChangeStateActiveQuestUI()
        {
            if(mainQuestHolder.transform.childCount != 0)
            {
                int num2 = mainQuestHolder.transform.childCount;
    
                for (int i = 0; i < num2; i++)
                {   
                    GameObject go = mainQuestHolder.transform.GetChild(i).gameObject;
                    QuestButton goQB = go.GetComponent<QuestButton>();
                    goQB.ButtonState();
                }
            }
        }
        
    }
}

