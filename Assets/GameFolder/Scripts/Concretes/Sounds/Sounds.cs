using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityProject3.Sound
{
    [System.Serializable]
    public class Sounds
    {
        public string Name;
        public AudioClip Clip;
        [Range(0,1)]
        public float Volume;
        [Range(0.1f,3f)]
        public float Pitch;
        public bool Loop;


        [HideInInspector]
        public AudioSource source;
    }
}
