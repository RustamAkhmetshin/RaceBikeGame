using System;
using Game;
using UnityEngine;

namespace Player
{
    public class DeathCollider : MonoBehaviour
    {
        public event Action Die;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.transform.CompareTag(Consts.GROUND_TAG_NAME))
            {
                Die?.Invoke();
            }
        }
    }
}