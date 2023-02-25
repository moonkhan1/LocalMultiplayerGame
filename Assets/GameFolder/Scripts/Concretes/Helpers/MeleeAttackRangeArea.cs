using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject3.ScriptableObjects;

namespace UnityProject3.Helpers
{

    public class MeleeAttackRangeArea : MonoBehaviour
    {
        [SerializeField] AttackSO _attackSO;
        void OnDrawGizmos() 
        {
            OnDrawGizmosSelected();
        }

        void OnDrawGizmosSelected() 
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, _attackSO.ValueForDistance);

        }
    }
}