using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpg{
    public class PlayerLevel : MonoBehaviour
    {
        public int level;
        public float[] experience;
        public float currentExp;
        public float maxExp;
        public float rate;
        private void Start() {
            experience = new float[100];
            for (int i = 0; i < experience.Length; i++)
            {
                experience[i] = (i*rate) * 120;
            }
        }

        public void CheckIfExpIsEnoughForLevelUp(){

            while (currentExp >= maxExp)
            {
                level++;
                maxExp = experience[level];
            }
        }
    }
}

