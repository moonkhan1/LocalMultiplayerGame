using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityProject3.Controllers
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] bool _canFire;
        [SerializeField] float _attackMaxDelay = 0.25f;
        [SerializeField] float _distance;
        [SerializeField] Camera _camera;
        [SerializeField] LayerMask _layerMask;

        float _currentTime = 0f;

        void Update()
        {
            _currentTime = Time.deltaTime;
            _canFire = _currentTime > _attackMaxDelay;    
        }

        public void Attack()
        {
            if(!_canFire) return;

            Ray ray = _camera.ViewportPointToRay(Vector3.one / 2f); // Ray tam olaraq ekranin ortasinda gorunsun
            
            if(Physics.Raycast(ray, out RaycastHit hit, _distance, _layerMask))
            {
                Debug.Log(hit.collider.gameObject.name);
            }
        _currentTime = 0f;
        }
    }
}