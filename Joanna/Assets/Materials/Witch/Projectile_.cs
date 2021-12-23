using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpg
{
    public class Projectile_ : MonoBehaviour
    {
        public float lifeTime;
        public float speed;
        public float damage;

        void Start()
        {
            lifeTime = 4f;
        }

        void Update()
        {   
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            lifeTime -= Time.deltaTime;
            if(lifeTime <= 0)
            {
                gameObject.SetActive(false);
            }
        }

        private void OnDisable() 
        {   
            lifeTime = 4f;
        }
        
        private void OnTriggerEnter(Collider other) 
        {
            IDamageble damagable = other.gameObject.GetComponent<IDamageble>();

            if(damagable == null)
                return;
                
            damagable.TakeDamage(damage);
        }
    }
}


