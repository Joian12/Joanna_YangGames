using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Collections;
using Unity.Rendering;
using Unity.Mathematics;

namespace rpg
{
    public class EnemyEntity : MonoBehaviour
    {   
        public GameObject spiderPrefab;
        public int spiderCount;
        private void Awake() 
        {
            var settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, null);
            var spiderPrefab_ = GameObjectConversionUtility.ConvertGameObjectHierarchy(spiderPrefab, settings);
            var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

            for (int i = 0; i < spiderCount; i++)
            {
                var instance = entityManager.Instantiate(spiderPrefab_);
                var position = transform.TransformPoint(new Vector3(5*i, 0, 35f));
                entityManager.SetComponentData(instance, new Translation{ Value = position});
                entityManager.SetComponentData(instance, new Rotation { Value = new Quaternion(0f, 0f, 0f, 1)});
            }
        }

#region     
        /*public Mesh spiderMesh;
        public Material spiderMat;
        void Start()
        {
            EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

            EntityArchetype entityArcheType = entityManager.CreateArchetype(
                typeof(EnemyStatComponent),
                typeof(Translation),
                typeof(RenderMesh),
                typeof(LocalToWorld)
            );

            NativeArray<Entity> entityArray = new NativeArray<Entity>(10, Allocator.Temp);

            entityManager.CreateEntity(entityArcheType ,entityArray);

            for (int i = 0; i < entityArray.Length; i++)
            {
                entityManager.SetComponentData(entityArray[i], new EnemyStatComponent{ currentHealth = 100 , maxHealth = 100});
                entityManager.SetSharedComponentData(entityArray[i], new RenderMesh{
                    mesh = spiderMesh,
                    material = spiderMat
                });
            }

           entityArray.Dispose();
        }*/
#endregion
    }
}

