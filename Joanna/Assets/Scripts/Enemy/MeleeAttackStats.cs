using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpg
{
    public class MeleeAttackStats : MonoBehaviour
    {   
        public float damage;
        public bool attack;

        private void Start()
        {
            attack = false;
        }
        private void OnTriggerStay(Collider other)
        {   
            if(other.gameObject.tag == "Player" && attack)
            {
                IDamageble iDamage = other.gameObject.GetComponent<IDamageble>();
                iDamage.TakeDamage(damage); 
            }    
        }
    }
}

