using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpg
{
    public class BarrelStats : MonoBehaviour, IDamageble
    {   
        public float currentHealth;
        public Material currentMat;
        public Material hitMat;

        public MeshRenderer meshRenderer;

        private void Start()
        {
            meshRenderer = GetComponentInChildren<MeshRenderer>();
        }

        private void Update()
        {
            meshRenderer.material = currentMat;    
        }
        public void TakeDamage(float damage)
        {
            currentHealth -= damage;    

            meshRenderer.material = hitMat;

            if(currentHealth <= 0)
            {
                gameObject.SetActive(false);
            }
        }


    }
}

