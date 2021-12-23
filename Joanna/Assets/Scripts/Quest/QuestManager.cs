using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace rpg
{  
    public class QuestManager : MonoBehaviour
    {   
        public static QuestManager instance; 
        public GameObject player;
        public List<Quest_Kill> allQuestKill = new List<Quest_Kill>();
        public List<Quest_Retrieve> allQuestRetrieve = new List<Quest_Retrieve>();
        public List<Quest_Travel> allQuestTravel = new List<Quest_Travel>();
        public Quest_UI questUI;
        public NPCInteract currentNPC;

        ////quest travel var
        public GameObject[] wayPoints;
        private GameObject[] destinations;

       public List<GameObject> wayPointList = new List<GameObject>();
       public List<GameObject> destinationList = new List<GameObject>();

        public void Awake()
        {
            instance = this;
            questUI = (Quest_UI)FindObjectOfType(typeof(Quest_UI));
            player = GameObject.FindGameObjectWithTag("Player").gameObject; 
            wayPoints = GameObject.FindGameObjectsWithTag("WayPoints");
            destinations = GameObject.FindGameObjectsWithTag("Destination");
            AddTravelQuest();
        }   

        private void Update()
        {
        
        }

        public void AddKillQuest(EnemyStats enemyStats, int killed)
        {
            for (int i = 0; i < allQuestKill.Count; i++)
            {   
                if(allQuestKill[i].alreadAdded && allQuestKill[i].enemyType == enemyStats.enemyType)
                {
                    allQuestKill[i].counter += killed;

                    if(allQuestKill[i].counter == allQuestKill[i].killRequirements)
                    {
                        allQuestKill[i].finished = true;
                    }
                }
            }
        }

        public void AddTravelQuest()
        {
            for (int i = 0; i < allQuestTravel.Count; i++)
            {
                if(allQuestTravel[i].alreadAdded)
                {
                    switch (allQuestTravel[i].location)
                    {                        
                        case Location.NPC:
                            NPCLocation(allQuestTravel[i].waypoints, allQuestTravel[i].destination);
                            break;
                        case Location.Utils:
                            Utility();
                            break;
                        case Location.Area:
                            Areas();
                            break;
                    }
                }
            }
        }

        private void NPCLocation(string[] way, string dest)
        {   
            if(destinations.Length != 0)
            {
                for (int i = 0; i < destinations.Length; i++)
                {
                    if(dest == destinations[i].name)
                    {
                        destinationList.Add(destinations[i]);
                    }
                }
            }
            
            if(wayPoints.Length != 0)
            {   
                for (int i = 0; i < way.Length; i++)
                {   
                    for (int j = 0; j < wayPoints.Length; j++)
                    {
                        if(way[i] == wayPoints[j].name)
                            wayPointList.Add(wayPoints[j]);
                    }
                }
            }
        }

        private void Utility()
        {
        
        }

        private void Areas()
        {

        }
    }

    public enum QuestType
    {
        MainQuest,
        SideQuest
    }

    
}

