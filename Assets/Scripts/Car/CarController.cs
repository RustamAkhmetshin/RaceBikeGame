using System;
using Game;
using UnityEngine;

namespace Player
{
    public class CarController : MonoBehaviour
    {
        [SerializeField] private Wheel wheelBack;
        [SerializeField] private Wheel wheelFront;
        [SerializeField] private Rigidbody2D carRigidbody;
        [SerializeField] private DeathCollider _deathCollider;
        
        private IInputManager _inputManager;
        private IGameManager _gameManager;
        private Car _car;
        private float _startX;
        private float _distance;
        
        private float _timer;

        private void Start()
        {
            _inputManager = Main.Instance.InputManager;
            _gameManager = Main.Instance.GameManager;
            _inputManager.OnInput += OnGetInput;
            _deathCollider.Die += Die;
        }

        public void Init(CarSettings settings)
        {
            _car = new Car(settings.Speed, settings.Torque, settings.StartPosition);
            transform.position = settings.StartPosition;
            _startX = settings.StartPosition.x;
            _distance = 0;
            _timer = 0;
        }

        private void Update()
        {
            _car.Position = transform.position;

            float newDistance = transform.position.x - _startX;

            if (newDistance > _distance)
            {
                _distance = newDistance;
            }

            _gameManager.UpdateScore((int)_distance);

            if (!wheelFront.IsGrounded() && wheelBack.IsGrounded())
            {
                _timer += Time.deltaTime;
            }
            else
            {
                _timer = 0;
            }

            if (_timer >= Consts.WHELEE_TIME)
            {
                _timer = 0;
                _gameManager.UpdateBonus(Consts.WHELEE_TEXT);
            }
        }

        private void FixedUpdate()
        {
            if (wheelBack.rigidbody.angularVelocity < 1000f && wheelFront.rigidbody.angularVelocity < 1000f)
            {
                wheelBack.AddTorque(_car.Movement * _car.Speed * Time.fixedDeltaTime);
                wheelFront.AddTorque(_car.Movement * _car.Speed * Time.fixedDeltaTime);
            }
            else
            {
                wheelBack.AddTorque(-_car.Speed * 5 * Time.fixedDeltaTime);
                wheelFront.AddTorque(-_car.Speed * 5 * Time.fixedDeltaTime);
            }

            if(!wheelBack.IsGrounded() || !wheelFront.IsGrounded())
                carRigidbody.AddTorque(-_car.Movement * _car.Torque * Time.fixedDeltaTime);
                
            _car?.FixedUpdate(Time.fixedDeltaTime);
        }

        private void Die()
        {
            _gameManager.Restart();
        }

        private void OnGetInput(ACTIONS action, int value)
        {
            switch (action)
            {
                case ACTIONS.LEFT:
                    _car.Movement = value;
                    break;
                
                case ACTIONS.RIGHT:
                    _car.Movement = value * -1;
                    break;
            }
        }

        private void OnDestroy()
        {
            _inputManager.OnInput -= OnGetInput;
            _deathCollider.Die -= Die;
        }
    }
}