using System;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class InputManager : MonoBehaviour, IInputManager
    {

        [SerializeField] private HoldableButton leftButton;
        [SerializeField] private HoldableButton rightButton;
        
        public event Action<ACTIONS, int> OnInput;

        public void Init()
        {
            leftButton.OnPressed += OnLeftPressed;
            rightButton.OnPressed += OnRightPressed;
        }

        public void OnUpdate(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.Escape)) 
            {
                Application.Quit();
            }
        }
        
        private void OnLeftPressed(bool value)
        {
            OnInput(ACTIONS.LEFT, value == true ? 1 : 0);
        }
        
        private void OnRightPressed(bool value)
        {
            OnInput(ACTIONS.RIGHT, value == true ? 1 : 0);
        }
        
        public void OnDelete()
        {
            leftButton.OnPressed = delegate(bool b) {  };
            rightButton.OnPressed = delegate(bool b) {  };
            OnInput = delegate {};
        }
    }
}