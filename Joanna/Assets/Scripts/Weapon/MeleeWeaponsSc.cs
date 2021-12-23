using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpg
{   
    [System.Serializable]
    public enum MeleeType
    {
        boxingGloves,
        swords
    } 

    [CreateAssetMenu(fileName = "Melee", menuName = "MeleeWeapon", order = 2)]
    public class MeleeWeaponsSc : ScriptableObject
    {
        public string meleeWeaponName;
        public MeleeType meleeType;
        public GameObject[] boxingGloves;
        public GameObject weapon;
        public float damage;
        public Vector3[] boxPosition;
        public Vector3[] boxRotation;
        public Vector3 position;
        public Vector3 rotation;
        public bool addedToInventory;
        public bool addedToChest;
    }
}

