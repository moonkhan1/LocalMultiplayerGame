using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityProject3.Abstracts.UIs;
using UnityProject3.Managers;

namespace UnityProject3.UIs
{
    public class PlayerJoinButton : ButtonBase
    {
        protected override void HandeOnClick()
        {
            GameManager.Instance.IncreasePlayerCount();
        }

    }
}