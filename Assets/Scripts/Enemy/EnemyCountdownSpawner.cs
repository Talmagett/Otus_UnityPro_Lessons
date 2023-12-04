using System;
using GameManager;
using UnityEngine;
using Zenject;

namespace Enemy
{
    public class EnemyCountdownSpawner : IGameUpdateListener,IDisposable
    {
        private readonly GameManager.GameManager _gameManager;
        private readonly EnemyManager _enemyManager;
        private const float SpawnCooldown = 1;
        private float _spawnTimer;
        
        [Inject]
        public EnemyCountdownSpawner(GameManager.GameManager gameManager,EnemyManager enemyManager)
        {
            _gameManager = gameManager;
            _enemyManager = enemyManager;
            _gameManager.AddListener(this);
        }
        
        public void Dispose()
        {
            _gameManager.RemoveListener(this);
        }

        public void OnGameUpdate(float deltaTime)
        {
            if (_spawnTimer > SpawnCooldown)
            {
                _enemyManager.Spawn();
                _spawnTimer = 0;
            }

            _spawnTimer += Time.deltaTime;
        }
    }
}