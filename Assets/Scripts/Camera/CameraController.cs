using System;
using UnityEngine;

namespace Game
{
    public class CameraController : MonoBehaviour, ICameraController
    {
        private Transform _target;
        private Vector3 _offset;


        private void Init()
        {
            _offset = transform.position - _target.position;
        }

        private void Update()
        {
            transform.position = _target.position + _offset;
        }

        public void SetFollowTarget(Transform target)
        {
            _offset = transform.position - target.position;
            _target = target;
        }
    }
}