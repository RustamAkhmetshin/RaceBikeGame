using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Player
{
    public class Car
    {
        private float _speed;
        private float _torque;
        private Vector2 _position;
        private float _movement;

        public Car(float speed, float torque, Vector2 position)
        {
            this._speed = speed;
            this._torque = torque;
            this._position = position;
        }

        public Vector2 Position
        {
            get => _position;
            set => _position = value;
        }

        public float Speed
        {
            get => _speed;
            set => _speed = value;
        }

        public float Torque
        {
            get => _torque;
            set => _torque = value;
        }

        public float Movement
        {
            get => _movement;
            set => _movement = value;
        }

        public void FixedUpdate(float fixedDeltaTime)
        {
            
        }
    }
}