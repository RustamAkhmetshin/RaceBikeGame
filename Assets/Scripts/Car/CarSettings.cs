using UnityEngine;

namespace Player
{
    [CreateAssetMenu( fileName = "CarSettings.asset", menuName = "Game/CarSettings" )]
    public class CarSettings : ScriptableObject
    {
        [SerializeField] private float speed;
        [SerializeField] private float torque;
        [SerializeField] private Vector2 startPosition;
        
        public float Speed => speed;

        public float Torque => torque;

        public Vector2 StartPosition => startPosition;
    }
}