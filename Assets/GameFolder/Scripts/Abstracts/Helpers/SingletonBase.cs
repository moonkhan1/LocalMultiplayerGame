using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityProject3.Abstracts.Helpers
{
    public abstract class SingletonBase<T> : MonoBehaviour where T : Component
    {
        public static T Instance { get; private set;}
         protected void MakeSingleton(T instance)
         {
            if(Instance == null)
            {
                Instance = instance;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
         }
    }
}