using GameManager;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyManager : MonoBehaviour, Listeners.IOnGameStarted, Listeners.IOnGameFinished,
        Listeners.IOnGamePaused, Listeners.IOnGameResumed
    {
        [SerializeField] private EnemyPool enemyPool;
        [SerializeField] private BulletSystem bulletSystem;

        private const float SpawnCooldown = 1;
        private float _spawnTimer;

        private bool _canSpawn;

        private void Update()
        {
            if (!_canSpawn)
                return;

            if (_spawnTimer > SpawnCooldown)
            {
                Spawn();
                _spawnTimer = 0;
            }

            _spawnTimer += Time.deltaTime;
        }

        private void Spawn()
        {
            var enemy = enemyPool.SpawnEnemy();
            if (enemy is not null)
            {
                enemy.GetComponent<HitPointsComponent>().HpEmpty += OnDestroyed;
                enemy.GetComponent<EnemyAttackAgent>().OnFire += OnFire;
            }
        }

        private void OnDestroyed(GameObject enemy)
        {
            enemy.GetComponent<HitPointsComponent>().HpEmpty -= OnDestroyed;
            enemy.GetComponent<EnemyAttackAgent>().OnFire -= OnFire;

            enemyPool.UnspawnEnemy(enemy);
        }

        private void OnFire(BulletConfig bulletConfig, Vector2 position, Vector2 direction)
        {
            bulletSystem.FlyBulletByArgs(new BulletSystem.Args
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