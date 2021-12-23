using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace rpg{
    public class QuestButton : MonoBehaviour{   
        public Quest_Kill kill;
        public Quest_Retrieve retrieve;
        public Quest_Travel travel;
        public GameObject canvas;
        public Quest_UI questUI;
        public RawImage image;
        public GameObject distanceImage;
        public TextMeshProUGUI text;
        public GameObject wayPoint;
        public GameObject destination;
        private float dist;
        private GameObject player;
        public bool isActive;
        
        private void Start() {
            canvas = GameObject.FindGameObjectWithTag("Canvas").gameObject;
            player = GameObject.FindGameObjectWithTag("Player").gameObject;
            questUI = canvas.transform.GetChild(6).gameObject.GetComponent<Quest_UI>();
            
            if(travel != null && travel.alreadAdded ){
                distanceImage.SetActive(true);
                GetWayPointsAndDestinations(travel);
                Debug.Log("Not NUll Travel");
            }
            else
                distanceImage.SetActive(false);
        }

        private void GetWayPointsAndDestinations(Quest_Travel travel_){
            for (int i = 0; i < QuestManager.instance.wayPointList.Count; i++){
                for (int j = 0; j < travel.waypoints.Length; j++){
                    if(travel_.waypoints[j] ==  QuestManager.instance.wayPointList[i].name){
                        wayPoint = QuestManager.instance.wayPointList[i];
                        Debug.Log( QuestManager.instance.wayPointList[i].name);
                    }
                }
            }

            for (int i = 0; i < QuestManager.instance.destinationList.Count; i++){
                if(travel_.destination == QuestManager.instance.destinationList[i].name)
                    destination = QuestManager.instance.destinationList[i];
            }
        }

        private void Update() {   
            if(this.transform.parent == null)
                Destroy(this.gameObject);

            if(wayPoint != null){
                dist = Vector3.Distance(wayPoint.transform.position, player.transform.position);
                float num = dist - 2f;
                text.text = num.ToString("F2");
                if(num < 1f )
                {      
                    travel.finished = true;
                    ButtonState();
                }
            }

            if(destination != null){
                dist = Vector3.Distance(destination.transform.position, player.transform.position);
                float num = dist - 2f;
                text.text = num.ToString("F2");

                if(num < 1f){                    
                    travel.finished = true;
                    ButtonState();
                }
            }  
        }

        public void ClickQuestButton(){   
            Activated(kill, retrieve, travel);
        }

        public void Activated(Quest_Kill kill_, Quest_Retrieve retrieve_, Quest_Travel travel_){

            if(kill_ != null && !kill_.alreadAdded && !kill_.finished){
                questUI.kill = kill_;
                kill.active = true;
                PromptUi();
            }

            if(retrieve_ != null && !retrieve_.alreadAdded && !retrieve_.finished){
                questUI.retrieve = retrieve_;
                retrieve.active = true;
                PromptUi();
            }

            if(travel_ != null && !travel_.alreadAdded && !travel_.finished){
                questUI.travel = travel_;
                travel.active = true;
                PromptUi();
            }
        }

        private void PromptUi(){
            questUI.confirmation.SetActive(true);
            questUI.ToBeAccepted.SetActive(false);
        }
        
        public void DoneQuestButton(){
            if(isActive)
                return;

            if(kill != null && kill.questType == QuestType.SideQuest || retrieve != null && retrieve.questType == QuestType.SideQuest || 
                travel != null && travel.questType == QuestType.SideQuest){
                if(kill != null && kill.finished  || retrieve != null && retrieve.finished || travel != null && travel.finished){
                    Debug.Log("finished");
                    questUI.awardInfo.SetActive(true);
                }
            }else{
                if(kill != null && kill.finished  || retrieve != null && retrieve.finished || travel != null && travel.finished){
                    Debug.Log("finished");
                    questUI.awardInfo.SetActive(true);
                }
            }
        }

        public void ButtonState(){
            if(kill != null && kill.finished){
                image.color = new Color32(204, 89, 31, 255);
            }
                   
            if(retrieve != null && retrieve.finished){
                Debug.Log("Retrieve Button Change");
                image.color = new Color32(204, 89, 31, 255);
            }
            
            if(travel != null && travel.finished){
                image.color = new Color32(204, 89, 31, 255);
            }
        }
    }
}


