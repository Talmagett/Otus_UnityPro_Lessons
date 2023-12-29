using Bullets;
using Components;
using UnityEngine;
using Zenject;

namespace Enemy
{
    public sealed class EnemyManager
    {
        private readonly EnemyFabric _enemyFabric;
        public EnemyManager(EnemyFabric enemyFabric)
        {
            _enemyFabric = enemyFabric;
        }

        public void Spawn()
        {
            var enemy = _enemyFabric.SpawnEnemy();
            enemy.GetComponent<HitPointsComponent>().OnHitPointsEmpty += OnDestroyed;

            enemy.Initialize();
        }

        private void OnDestroyed(GameObject enemy)
        {
            enemy.GetComponent<HitPointsComponent>().OnHitPointsEmpty -= OnDestroyed;
            
            var enemyComponent = enemy.GetComponent<Enemy>();
            enemyComponent.Dispose();
            
            _enemyFabric.UnspawnEnemy(enemyComponent);
        }
    }
}