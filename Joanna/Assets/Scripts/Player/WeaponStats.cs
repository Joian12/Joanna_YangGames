using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpg
{
    public class WeaponStats : MonoBehaviour
    {
        public float damage;
        public bool isDamaging;
        public Transform me;

        private void Start() 
        {
           
        }
        private void OnTriggerStay(Collider other) 
        {       
            
            if(other.gameObject.tag == "Enemy" && isDamaging)
            {   
                me.LookAt(other.gameObject.transform.position);
                Debug.Log("tagging enemy");   
                IDamageble idm = other.gameObject.GetComponent<IDamageble>();
                idm.TakeDamage(damage);
            }
        }
    }
}


