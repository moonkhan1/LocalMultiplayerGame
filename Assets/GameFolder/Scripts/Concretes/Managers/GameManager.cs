using UnityEngine;
using UnityProject3.Abstracts.Helpers;
using UnityProject3.Controllers;

namespace UnityProject3.Managers
{
    public class GameManager : SingletonBase<GameManager>
    {
        void Awake() 
        {
            MakeSingleton(this);
        }
    }
}