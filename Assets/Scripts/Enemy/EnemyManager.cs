using System.Collections.Generic;
using GameManager;
using UnityEngine;
using UnityEngine.Serialization;

namespace ShootEmUp
{
    public sealed class EnemyManager : MonoBehaviour
    {
        [SerializeField] private EnemySpawner enemySpawner;
        [SerializeField] private BulletSystem bulletSystem;

        [SerializeField] private GameManager.GameManager manager;
        public void Spawn()
        {
            var enemy = enemySpawner.SpawnEnemy();
            enemy.GetComponent<HitPointsComponent>().OnHitPointsEmpty += OnDestroyed;
            enemy.GetComponent<EnemyAttackAgent>().OnFire += OnFire;
            
            manager.AddListeners(enemy.GetComponents<IGameListener>());
        }

        private void OnDestroyed(GameObject enemy)
        {
            enemy.GetComponent<HitPointsComponent>().OnHitPointsEmpty -= OnDestroyed;
            enemy.GetComponent<EnemyAttackAgent>().OnFire -= OnFire;

            enemySpawner.UnspawnEnemy(enemy.GetComponent<Enemy>());
            manager.RemoveListeners(enemy.GetComponents<IGameListener>());
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
    }
}