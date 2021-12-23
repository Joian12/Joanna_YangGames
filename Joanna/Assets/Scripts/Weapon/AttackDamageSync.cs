using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpg
{
    public class AttackDamageSync : MonoBehaviour
    {
        public bool attackSync;

        private void Start() 
        {
            attackSync = false;
        }

        public void OpenAttackCollider()
        {
            attackSync = true;
        }

        public void CloseAttackCollider()
        {
            attackSync = false;
        }
    }
}


