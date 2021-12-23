using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpg
{   
    [CreateAssetMenu(fileName = "Quest Travel", menuName = "Quest Travel Template", order = 2)]
    public class Quest_Travel : ScriptableObject
    {
        public string questName;
        public string nextQuestName;
        public Location location;
        public NPCNames npcnNames;
        public Utility utils;
        public Areas areas;
        public QuestType questType;
        public bool active;
        public bool mainActive;
        public bool alreadAdded;
        public bool finished;
        public bool done;

        public string[] waypoints;
        public string destination;
    }  

    public enum Location
    {
        NPC, Utils, Area
    }

    public enum Utility
    {
        InventoryChest
    }

    public enum Areas
    {
        AngelStatue
    }
}


