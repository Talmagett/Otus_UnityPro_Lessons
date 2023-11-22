using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyManager : MonoBehaviour, Listeners.IOnGameStarted, Listeners.IOnGameFinished,
        Listeners.IOnGamePaused, Listeners.IOnGameResumed
    {
        [SerializeField] private EnemySpawner enemySpawner;

        [SerializeField] private BulletSystem bulletSystem;

        private bool _canSpawn;
        public void Spawn()
        {
            var enemy = enemySpawner.SpawnEnemy();
            enemy.GetComponent<HitPointsComponent>().OnHitPointsEmpty += OnDestroyed;
            enemy.GetComponent<EnemyAttackAgent>().OnFire += OnFire;
        }

        private void OnDestroyed(GameObject enemy)
        {
            enemy.GetComponent<HitPointsComponent>().OnHitPointsEmpty -= OnDestroyed;
            enemy.GetComponent<EnemyAttackAgent>().OnFire -= OnFire;

            enemySpawner.UnspawnEnemy(enemy.GetComponent<Enemy>());
        }

        private void OnFire(BulletConfig bulletConfig, Vector2 position, Vector2 direction)
        {
            bulletSystem.SpawnBullet(new BulletSystem.Args
            {
                isPlayer = false,
                physicsLayer = (int)bulletConfig.physicsLayer,
                color = bulletConfig.color,
                damage = bulletConfig.damage,
                position = position,
                velocity = direction * bulletConfig.speed
            });
        }

        public void OnGameStarted()
        {
            _canSpawn = true;
        }

        public void OnGameFinished()
        {
            _canSpawn = false;
        }

        public void OnGamePaused()
        {
            _canSpawn = false;
        }

        public void OnGameResumed()
        {
            _canSpawn = true;
        }
    }
}