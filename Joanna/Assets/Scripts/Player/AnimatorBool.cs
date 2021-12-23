using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpg
{
    public class AnimatorBool : MonoBehaviour
    {
       public WeaponStats weaponStats;

       public void OpenDamageCollider()
       {
           weaponStats.isDamaging = true;
       }
       public void CloseDamageCollider()
       {
           weaponStats.isDamaging = false;
       }
    }
}

