using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpg
{
    public class SpiderTest : MonoBehaviour
    {
        void Update()
        {
            transform.Rotate(Vector3.up, 20f * Time.deltaTime);
        }
    }
}

