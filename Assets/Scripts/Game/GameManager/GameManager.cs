using System;
using Player;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class GameManager : MonoBehaviour, IGameManager
    {
        public event Action<int> OnScoreUpdated;
        public event Action<string> OnGetBonus;
        
        private IDataManager _dataManager;
        private IUIManager _uiManager;
        private ICameraController _cameraController;
        
        public void Init()
        {
            _dataManager = Main.Instance.DataManager;
            _uiManager = Main.Instance.UIManager;

            _uiManager.Init();

            var car = Instantiate(_dataManager.LoadPrefab(Consts.CAR_PREFAB_PATH));
            var carSettings = _dataManager.LoadAsset(Consts.CAR_SETTINGS_PATH);
            var carController = car.GetComponent<CarController>();
            carController.Init((CarSettings)carSettings);

            _cameraController = Instantiate(_dataManager.LoadPrefab(Consts.PLAYER_CAMERA_PREFAB_PATH)).GetComponent<CameraController>();
            _cameraController.SetFollowTarget(car.transform);
        }

        public void Restart()
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        }

        public void OnUpdate(float deltaTime) { }

        public void UpdateScore(int value)
        {
            OnScoreUpdated?.Invoke(value);
        }
        
        public void UpdateBonus(string bonus)
        {
            OnGetBonus?.Invoke(bonus);
        }
        //
        public void OnDelete()
        {
            OnGetBonus = delegate(string s) {  };
            OnScoreUpdated = delegate(int i) {  };
        }
    }
}