using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpg
{
    public class Swords : MonoBehaviour
    {
        public MeleeWeaponsSc rwSC;
        public AttackDamageSync attackDamageSync;

        private void Awake() 
        {
            attackDamageSync = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponentInChildren<AttackDamageSync>();
        }

        private void Attacking(IDamageble idamage)
        {
            if(idamage != null && attackDamageSync.attackSync)
            {
                Debug.Log("Enemy or Item that can be damaged");
                idamage.TakeDamage(rwSC.damage);
            }
        }
        
        private void OnTriggerStay(Collider other) 
        {
            IDamageble idamage = other.GetComponent<IDamageble>();
            Attacking(idamage);
        }

        private void OnTriggerExit(Collider other) 
        {   
            IDamageble idamage = other.GetComponent<IDamageble>();
            idamage = null;    
        }
    }
}

