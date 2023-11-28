using Common;
using Components;
using Enemy.Agents;
using UnityEngine;

namespace Enemy
{
    public sealed class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemyPositions enemyPositions;
        [SerializeField] private HitPointsComponent character;
        [SerializeField] private Pool<Enemy> pool;

        [SerializeField] private Transform worldTransform;

        private void Awake()
        {
            pool.InitSpawn();
        }

        public Enemy SpawnEnemy()
        {
            var enemy = pool.GetInstance(worldTransform);

            var spawnPosition = enemyPositions.RandomSpawnPosition();
            enemy.transform.position = spawnPosition.position;

            var attackPosition = enemyPositions.RandomAttackPosition();

            enemy.GetComponent<EnemyMoveAgent>().SetDestination(attackPosition.position);
            enemy.GetComponent<EnemyAttackAgent>().SetTarget(character);
            return enemy;
        }

        public void UnspawnEnemy(Enemy enemy)
        {
            pool.Release(enemy);
        }
    }
}