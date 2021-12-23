using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpg
{   
    [CreateAssetMenu(fileName = "Quest Kill", menuName = "Quest Kill Template", order = 2)]
    public class Quest_Kill : ScriptableObject
    {
        public string questName;
        public string nextQuestName;
        public NPCNames npcnNames;
        public QuestType questType;
        public EnemyType enemyType;

        public bool active;
        public bool mainActive;
        public bool alreadAdded;
        public bool finished;
        public bool done;
        
        public int counter;
        public int killRequirements;
    }

    public enum EnemyType
    {
        normal_zombie, slender_zombie, spider, skeleton
    }

    public enum EnemyRank
    {
        normal, boss
    }
}


