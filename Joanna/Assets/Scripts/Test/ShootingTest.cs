using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpg
{
    public class ShootingTest : MonoBehaviour
    {
        public GameObject projectile;
        public float secBeforeShoot;
        public float temp;
        void Start()
        {
            
        }

        void Update()
        {
            secBeforeShoot += Time.deltaTime;

            if(secBeforeShoot >= 2f)
            {
                Instantiate(projectile, transform.position, transform.rotation);
                secBeforeShoot = temp;
            }
        }
    }
}

