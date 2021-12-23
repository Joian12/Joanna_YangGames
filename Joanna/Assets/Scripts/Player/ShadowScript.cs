using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpg
{
    public class ShadowScript : MonoBehaviour
    {
        public Transform shadow;
        public Transform player;
        public Transform lightBulb;
        private Vector3 rot, scl;
        private float dis;
        public float divider;
        public Color a,b;
        public SpriteRenderer spr;

        private void Start() {
            player = GameObject.FindGameObjectWithTag("Player").gameObject.transform;
            this.transform.SetParent(player);
        }

        void Update()
        {   
            if(lightBulb != null)
            {   
                dis = Vector3.Distance(shadow.position, lightBulb.position);
                shadow.LookAt(lightBulb);
                rot = shadow.eulerAngles;
                spr.color = a;//new Color(spr.color[0], spr.color[1], spr.color[2], a);
                scl = shadow.localScale;
                scl.z = dis/divider;  
                shadow.localScale = scl;
                rot.x = 0f;
                shadow.eulerAngles = rot;
            }
            else
            {
                //shadow.eulerAngles = Vector3.zero;
                spr.color = b; 
                scl = Vector3.one;
                shadow.localScale = scl;
                shadow.localRotation = Quaternion.Euler(0,0,0);
            }
            
        }
    }
}


