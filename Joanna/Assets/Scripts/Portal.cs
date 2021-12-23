using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace rpg
{
    public class Portal : MonoBehaviour
    {   
        public PortalDestination destination;
        private void OnTriggerEnter(Collider other) 
        {
            if(other.CompareTag("Player"))
            {
                FirebaseInstance.instance.SaveAllWeaponData();
                FirebaseInstance.instance.SaveAllQuestData();
                SceneManager.LoadScene(destination.ToString(), LoadSceneMode.Single);
            }    
        }

        private void SaveAllToNextScene(){
            
        }
    }


    public enum PortalDestination
    {
        TestScene,
        TestScene_2,
        TestScene_3
    }
}


