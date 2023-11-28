using Bullets;
using Components;
using UnityEngine;

namespace Enemy
{
    public sealed class EnemyManager : MonoBehaviour
    {
        [SerializeField] private EnemySpawner enemySpawner;

        [Space] 
        [SerializeField] private BulletSystem bulletSystem;
        [SerializeField] private GameManager.GameManager manager;

        public void Spawn()
        {
            var enemy = enemySpawner.SpawnEnemy();
            enemy.GetComponent<HitPointsComponent>().OnHitPointsEmpty += OnDestroyed;

            enemy.Construct(manager, bulletSystem);
            enemy.Initialize();
        }

        private void OnDestroyed(GameObject enemy)
        {
            enemy.GetComponent<HitPointsComponent>().OnHitPointsEmpty -= OnDestroyed;
            var enemyComponent = enemy.GetComponent<Enemy>();
            enemyComponent.Dispose();
            enemySpawner.UnspawnEnemy(enemyComponent);
        }
    }
}