using UnityEngine;

namespace rpg{
    public class TravelLocation : MonoBehaviour, I_Interact{   
        public Quest_UI questUI;
        public GameObject canvas, control, weaponToggles;

        public void Start(){
            questUI = (Quest_UI)FindObjectOfType(typeof(Quest_UI));
            canvas = questUI.gameObject.transform.parent.gameObject;
            control = canvas.transform.GetChild(0).gameObject;
            weaponToggles = canvas.transform.GetChild(1).gameObject;
        }

        private void OnTriggerEnter(Collider other){
            if(other.CompareTag("Player"))
            {
                Debug.Log("Player finished this quest");
            }
        }

        public void Interact(){   
            questUI.quest_NotActive.ResetFromNPC();
            questUI.quest_NotActive.QuestTravelLocation(this.gameObject.name);
            questUI.quest_NotActive.RemovedFromActiveList();;
            questUI.quest_NotActive.ChangeStateQuestUI();
            questUI.quest_NotActive.ChangeStateActiveQuestUI();
            questUI.ToBeAccepted.SetActive(true);
            control.SetActive(false);
            weaponToggles.SetActive(false);
        }

        public void DeInteract()
        {

        }
    }
}

