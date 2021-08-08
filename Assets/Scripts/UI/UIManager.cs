using System.Collections;
using Game;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIManager : MonoBehaviour, IUIManager
    {
        [SerializeField] private Text distanceText;
        [SerializeField] private Text wheleeText;
        [SerializeField] private Button restartButton;

        private IGameManager _gameManager;

        public void Init()
        {
            _gameManager = Main.Instance.GameManager;
            _gameManager.OnScoreUpdated += OnScoreUpdated;
            _gameManager.OnGetBonus += OnGetBonus;
            
            restartButton.onClick.AddListener(Restart);
            
            OnScoreUpdated(0);
            OnGetBonus("");
        }

        private void OnScoreUpdated(int value)
        {
            distanceText.text = value.ToString();
        }

        private void OnGetBonus(string bonus)
        {
            wheleeText.text = bonus;
            StartCoroutine("ClearText");
        }

        private void Restart()
        {
            _gameManager.Restart();
        }

        private IEnumerator ClearText()
        {
            yield return new WaitForSeconds(1);
            wheleeText.text = "";
        }

        public void OnDelete()
        {
            _gameManager.OnScoreUpdated -= OnScoreUpdated;
            _gameManager.OnGetBonus -= OnGetBonus;
            restartButton.onClick.RemoveAllListeners();
        }
    }
}