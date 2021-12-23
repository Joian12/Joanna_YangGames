using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpg
{
   public class ShadowParameters : MonoBehaviour
    {   
        public ShadowScript shadowScript;
        public Transform lightBulb;
        private void OnTriggerEnter(Collider other) {
            if(other.gameObject.CompareTag("Player")){
                GameObject player = other.gameObject;
                shadowScript = player.GetComponentInChildren<ShadowScript>();
                shadowScript.lightBulb = lightBulb;
            }
        }

        private void OnTriggerExit(Collider other) {
            if(other.gameObject.CompareTag("Player")){
                GameObject player = other.gameObject;
                shadowScript = player.GetComponentInChildren<ShadowScript>();
                shadowScript.lightBulb = null;
                shadowScript = null;
            }
        }
    } 
}

