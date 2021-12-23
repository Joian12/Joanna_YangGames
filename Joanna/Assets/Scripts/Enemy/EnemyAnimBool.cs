using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpg
{
    public class EnemyAnimBool : MonoBehaviour
    {
        public MeleeAttackStats mAttacsk;
        public MeleeAttackStats[] meleeAttackStats;
        public void Open()
        {   
            mAttacsk.attack = true;
        }

        public void Close()
        {
            mAttacsk.attack = false;
        }

        public void BossOpenLeft()
        {
            meleeAttackStats[0].attack = true;
        }

        public void BossCloseLeft()
        {
            meleeAttackStats[0].attack = false;
        }

        public void BossOpenRight()
        {
            meleeAttackStats[1].attack = true;
        }   

        public void BossCloseRight()
        {
            meleeAttackStats[1].attack = false;
        }
    }
}

