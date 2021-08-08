using System;
using Game;
using UnityEngine;

namespace Player
{
    public class Wheel : MonoBehaviour
    {
        [SerializeField] private float groundCheckRadius;
        [SerializeField] private LayerMask groundLayer;
        
        [HideInInspector]
        public Rigidbody2D rigidbody;

        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody2D>();
        }

        public bool IsGrounded()
        {
            Collider2D coll = Physics2D.OverlapCircle (transform.position, groundCheckRadius, groundLayer);
            if(!coll) return false;
            return true;
        }

        public void AddTorque(float t)
        {
            rigidbody.AddTorque(t);
        }
    }
}