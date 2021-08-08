using System;
using UnityEngine;
using UnityEngine.U2D;
using Random = UnityEngine.Random;

namespace Game.GroundTerrain
{
    public class TerrainGenerator : MonoBehaviour
    {
        private SpriteShapeController _spriteShape;
        
        private int pointDistance;

        private IGameManager _gameManager;
        private int _startPointsNum = 20;
        private int _currentPointsCount = 20;
        private int _startScale = 100;
        
        private int _step = 70;
        

        private void Awake()
        {
            _spriteShape = GetComponent<SpriteShapeController>();
        }

        private void Start()
        {
            _gameManager = Main.Instance.GameManager;
            _gameManager.OnScoreUpdated += CheckForDistance;

            pointDistance = _startScale / _startPointsNum;
            
            _spriteShape.spline.SetPosition(2, 
                _spriteShape.spline.GetPosition(2) + Vector3.right * _startScale);
            _spriteShape.spline.SetPosition(3, 
                _spriteShape.spline.GetPosition(3) + Vector3.right * _startScale);

            for (int i = 0; i < _startPointsNum; i++)
            {
                float xPosition = _spriteShape.spline.GetPosition(i + 1).x + pointDistance;
                _spriteShape.spline.InsertPointAt(i + 2, new Vector3(xPosition, 
                    5f * Mathf.PerlinNoise(i * Random.Range(5f, 15f), 0)));
            }

            for (int i = 2; i < _startPointsNum + 2; i++)
            {
                _spriteShape.spline.SetTangentMode(i, ShapeTangentMode.Continuous);
                _spriteShape.spline.SetLeftTangent(i, new Vector3(-1, 0, 0));
                _spriteShape.spline.SetRightTangent(i, new Vector3(1,0,0));
            }
            
            _spriteShape.autoUpdateCollider = true;
        }

        public void CheckForDistance(int currentDistance)
        {
            if (currentDistance > _step)
            {
                Generate();
                _step += 70;
            }
        }

        private void Generate()
        {
            pointDistance = _startScale / _startPointsNum;
            
            _spriteShape.spline.SetPosition(2 + _currentPointsCount, 
                _spriteShape.spline.GetPosition(2 + _currentPointsCount) + Vector3.right * _startScale);
            _spriteShape.spline.SetPosition(3 + _currentPointsCount, 
                _spriteShape.spline.GetPosition(3 + _currentPointsCount) + Vector3.right * _startScale);
            
            for (int i = 0; i < _startPointsNum; i++)
            {
                float xPosition = _spriteShape.spline.GetPosition(i + 1 + _currentPointsCount).x + pointDistance;
                _spriteShape.spline.InsertPointAt(i + 2 + _currentPointsCount, new Vector3(xPosition, 
                    5f * Mathf.PerlinNoise(i * Random.Range(5f, 15f), 0)));
            }
            
            for (int i = 2 + _currentPointsCount; i < _currentPointsCount + _startPointsNum + 2; i++)
            {
                _spriteShape.spline.SetTangentMode(i, ShapeTangentMode.Continuous);
                _spriteShape.spline.SetLeftTangent(i, new Vector3(-1, 0, 0));
                _spriteShape.spline.SetRightTangent(i, new Vector3(1,0,0));
            }

            _spriteShape.UpdateSpriteShapeParameters();
            _currentPointsCount += _startPointsNum;
        }

        private void OnDestroy()
        {
            _gameManager.OnScoreUpdated -= CheckForDistance;
        }
    }
}