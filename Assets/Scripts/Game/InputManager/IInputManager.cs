using System;

namespace Game
{
    public enum ACTIONS 
    {
        LEFT, RIGHT,
    }
    
    public interface IInputManager
    {
        void Init();
        void OnUpdate(float deltaTime);
        void OnDelete();
        event Action<ACTIONS, int> OnInput;
    }
}