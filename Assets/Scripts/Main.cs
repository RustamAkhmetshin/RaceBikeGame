using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

namespace Game
{
    public class Main : MonoBehaviour
    {
        public static Main Instance;

        private IInputManager _inputManager;
        private IGameManager _gameManager;
        private IDataManager _dataManager;
        private IUIManager _uiManager;

        private void Awake()
        {
            Instance = this;
            
            _dataManager = new DataManager();
            
            _inputManager = Instantiate(_dataManager.LoadPrefab(Consts.INPUT_MANAGER_PREFAB_PATH)).GetComponent<InputManager>();
            
            _uiManager = Instantiate(_dataManager.LoadPrefab(Consts.UI_MANAGER_PREFAB_PATH)).GetComponent<UIManager>();
            
            _gameManager = Instantiate(_dataManager.LoadPrefab(Consts.GAME_MANAGER_PREFAB_PATH)).GetComponent<GameManager>();
            
            _inputManager.Init();
            _gameManager.Init();
        }

        private void Start()
        {

        }

        public IInputManager InputManager => _inputManager;
        
        public IDataManager DataManager => _dataManager;
        
        public IUIManager UIManager => _uiManager;
        
        public IGameManager GameManager => _gameManager;

        private void Update()
        {
            float dt = Time.deltaTime;
            _inputManager.OnUpdate(dt);
            _gameManager.OnUpdate(dt);
        }

        private void OnDestroy()
        {
            _inputManager.OnDelete();
            _gameManager.OnDelete();
            _dataManager.OnDelete();
            _uiManager.OnDelete();
        }
    }
}