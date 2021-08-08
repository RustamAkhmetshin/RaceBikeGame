using System;

namespace Game
{
    public interface IGameManager
    {
        void Init();
        void Restart();
        void OnUpdate(float deltaTime);
        void OnDelete();
        void UpdateScore(int value);
        void UpdateBonus(string bonus);
        
        event Action<int> OnScoreUpdated;
        event Action<string> OnGetBonus;
    }
}