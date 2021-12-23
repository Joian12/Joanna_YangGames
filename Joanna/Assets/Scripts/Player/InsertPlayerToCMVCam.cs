using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace rpg
{
    public class InsertPlayerToCMVCam : MonoBehaviour
    {
        public Transform player;
        public CinemachineVirtualCamera cmVC;
        void Awake()
        {   
            
        }

        void Update()
        {      
            if(player == null)
            {
                player = GameObject.FindGameObjectWithTag("Player").gameObject.transform;
            }
            
            cmVC.LookAt = player;
            cmVC.Follow = player;
        }
    }
}

