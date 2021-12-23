using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpg
{   
    [CreateAssetMenu(fileName = "Range", menuName = "RangeWeapon", order = 1)]
    public class RangeWeaponSC : ScriptableObject
    {   
        public string rangeWeaponName;
        public GameObject rangeWeaponObject;
        public GameObject bulletObject;
        public int bulletCount;
        public int maxBulletCount;
        public int currentInventoryNum;
        public float damage;
        public Vector3 position;
        public Vector3 rotation;
        public float nextShoot;
        public bool addedToInventory;
        public bool addedToChest;
        public bool isActive;
        public bool currentUsed;
    }
}


