using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace rpg
{   
    [System.Serializable]
    public class Object_Pools
    {
        public string name; 
        public GameObject objectToPool;
        public int size;
    }

    public class ObjectPooler_ : MonoBehaviour
    {   
        public GameObject[] projectileParent;
        public GameObject enemyParent;

        public List<Object_Pools> projectileObj = new List<Object_Pools>();

        public Dictionary<string, Queue<GameObject>> allPooledObjects = new Dictionary<string, Queue<GameObject>>();


        public void SettingProjectilePool()
        {   
            if (InventoryMain.Instance.inventoryRange.Count == 0)
                return;

            for (int i = 0; i < InventoryMain.Instance.inventoryRange.Count; i++)
            {   
                if(InventoryMain.Instance.inventoryRange[i] !=  null)
                {   
                    projectileObj[i].name = InventoryMain.Instance.inventoryRange[i].rangeWeaponName;
                    projectileObj[i].objectToPool = InventoryMain.Instance.inventoryRange[i].bulletObject;
                    projectileObj[i].size = InventoryMain.Instance.inventoryRange[i].maxBulletCount;
                }
                else
                {
                    projectileObj[i].name = " ";
                    projectileObj[i].objectToPool = null;
                    projectileObj[i].size = 0;
                }
            }

            for (int i = 0; i < projectileObj.Count; i++)
            {  
                Queue<GameObject> goQue = new Queue<GameObject>();

                for (int j = 0; j < projectileObj[i].size; j++)
                {
                    int num = projectileParent[i].transform.childCount;
                        
                    if(num != projectileObj[i].size)
                    {   
                        GameObject go = Instantiate(projectileObj[i].objectToPool);
                        go.transform.SetParent(projectileParent[i].transform);
                        go.SetActive(false);
                        goQue.Enqueue(go);
                    }   
                }

                if(!allPooledObjects.ContainsKey(projectileObj[i].name))
                {
                    allPooledObjects.Add(projectileObj[i].name, goQue);
                }
            }
        }

        public GameObject SpawProjectile(string name, Vector3 position, Quaternion rotation)
        {   
            if(!allPooledObjects.ContainsKey(name))
                return null;

            GameObject projGo = allPooledObjects[name].Dequeue();
            projGo.transform.position = position;
            projGo.transform.rotation = rotation;
            projGo.SetActive(true);

            allPooledObjects[name].Enqueue(projGo);

            return projGo;
        }
    }
}


