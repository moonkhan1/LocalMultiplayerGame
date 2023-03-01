using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityProject3.Combats
{

    public class Dead : MonoBehaviour
    {
        [SerializeField] float _delayTime = 5f;

        public void DeadAction()
        {
            StartCoroutine(DeadActionAsync());
        }

        private IEnumerator DeadActionAsync()
        {   
            yield return new WaitForSeconds(_delayTime);

            Destroy(this.gameObject);

        }
    }
}
