using UnityEngine;
using UnityEngine.UI;
using UnityProject3.Managers;
using System;
using UnityProject3.Abstracts.UIs;

namespace UnityProject3.UIs
{
    public class StartButton : ButtonBase
    {
        protected override void HandeOnClick()
        {
            GameManager.Instance.LoadScene("Game");
        }

    }
}