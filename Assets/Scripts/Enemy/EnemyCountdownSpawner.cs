using GameManager;
using UnityEngine;

namespace ShootEmUp
{
    public class EnemyCountdownSpawner : MonoBehaviour, IGameUpdateListener
    {
        [SerializeField] private EnemyManager enemyManager;

        private const float SpawnCooldown = 1;
        private float _spawnTimer;

        public void OnGameUpdate(float deltaTime)
        {
            if (_spawnTimer > SpawnCooldown)
            {
                enemyManager.Spawn();
                _spawnTimer = 0;
            }

            _spawnTimer += deltaTime;
        }
    }
}