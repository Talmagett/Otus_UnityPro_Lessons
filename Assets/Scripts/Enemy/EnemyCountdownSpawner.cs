using UnityEngine;
using UnityEngine.Serialization;

namespace ShootEmUp
{
    public class EnemyCountdownSpawner:MonoBehaviour
    {
        [SerializeField] private EnemyManager enemyManager;
        
        private const float SpawnCooldown = 1;
        private float _spawnTimer=0;
        
        private void Update()
        {
            if (_spawnTimer > SpawnCooldown)
            {
                enemyManager.Spawn();
                _spawnTimer = 0;
            }

            _spawnTimer += Time.deltaTime;
        }
    }
}