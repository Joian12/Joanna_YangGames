using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

namespace rpg
{
    public struct EnemyStatComponent : IComponentData
    {
        public float currentHealth;
        public float maxHealth;
    }
}

