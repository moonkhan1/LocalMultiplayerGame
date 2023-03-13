using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject3.Abstracts.Movements;

namespace UnityProject3.Movements
{
    public class SpineRotationX : IRotator
    {
        private Transform _transform;
        private float _tilt;
        
        public SpineRotationX(Transform transform)
        {
            _transform = transform;
        }
        public void RotationAction(float direction, float speed)
        {
            direction *= speed * Time.deltaTime;
            _tilt = Mathf.Clamp(_tilt - direction, -30f, 30);
            _transform.Rotate(new Vector3(_tilt,0f,0f));
        }
    }
}