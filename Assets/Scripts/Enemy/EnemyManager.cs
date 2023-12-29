using Bullets;
using Components;
using UnityEngine;
using Zenject;

namespace Enemy
{
    public sealed class EnemyManager
    {
        private readonly EnemySpawner _enemySpawner;
        private readonly BulletSystem _bulletSystem;
        private readonly GameManager.GameManager _gameManager;

        public EnemyManager(GameManager.GameManager gameManager,EnemySpawner enemySpawner,BulletSystem bulletSystem)
        {
            _gameManager = gameManager;
            _enemySpawner = enemySpawner;
            _bulletSystem = bulletSystem;
        }

        public void Spawn()
        {
            var enemy = _enemySpawner.SpawnEnemy();
            enemy.GetComponent<HitPointsComponent>().OnHitPointsEmpty += OnDestroyed;

            enemy.Construct(_gameManager, _bulletSystem);
            enemy.Initialize();
        }

        private void OnDestroyed(GameObject enemy)
        {
            enemy.GetComponent<HitPointsComponent>().OnHitPointsEmpty -= OnDestroyed;
            var enemyComponent = enemy.GetComponent<Enemy>();
            enemyComponent.Dispose();
            _enemySpawner.UnspawnEnemy(enemyComponent);
        }
    }
}