using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpg
{
    public class AudioPlayer : MonoBehaviour
    {
        public AudioSource audioData;
        void Start()
        {
            audioData.Play(0);
        }
    }
}

