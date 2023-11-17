using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyManager : MonoBehaviour
    {
        [SerializeField] private EnemyPool enemyPool;
        [SerializeField] private BulletSystem bulletSystem;

        private const float SpawnCooldown = 1;
        private float _spawnTimer=0;

        private void Update()
        {
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
    }
}