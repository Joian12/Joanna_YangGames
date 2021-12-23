using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpg
{   
    [CreateAssetMenu(fileName = "Quest Retrieve", menuName = "Quest Retrieve Template", order = 2)]
    public class Quest_Retrieve : ScriptableObject
    {
        public string questName;
        public string itemName;
        public string message;
        public string nextQuestName;
        public NPCNames npcnNames;
        public QuestType questType;
        public bool active;
        public bool mainActive;
        public bool alreadAdded;
        public bool finished;
        public bool done;
    }
}
