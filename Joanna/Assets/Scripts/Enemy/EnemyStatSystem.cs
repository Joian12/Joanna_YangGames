using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

namespace rpg
{
    public class EnemyStatSystem : ComponentSystem
    {
        protected override void OnUpdate()
        {
            Entities.ForEach((ref EnemyStatComponent enemyStatComponent) => 
            {

            });
        }
    }
}

