using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject3.Abstracts.UIs;
using UnityProject3.Managers;

namespace UnityProject3.UIs
{
    public class ReturnButton : ButtonBase
    {
        protected override void HandeOnClick()
        {
            GameManager.Instance.ReturnMenuOnAllPlayerDead();
        }
    }
}