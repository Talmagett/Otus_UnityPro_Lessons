using Common;
using Components;
using Enemy.Agents;
using UnityEngine;
using Zenject;

namespace Enemy
{
    public sealed class EnemySpawner
    {
        private readonly EnemyPositions _enemyPositions;
        private readonly HitPointsComponent _character;
        private readonly Pool<Enemy> _pool;

        private readonly Transform _worldTransform;
        
        public EnemySpawner(EnemyPositions enemyPositions, HitPointsComponent character,
            PoolArgs<Enemy> enemyPoolArgs)
        {
            _enemyPositions = enemyPositions;
            _character = character;
            _worldTransform = enemyPoolArgs.WorldTransform;
            _pool = new Pool<Enemy>(enemyPoolArgs.Prefab,enemyPoolArgs.Container,enemyPoolArgs.InitialCount);
        }

        public Enemy SpawnEnemy()
        {
            var enemy = _pool.GetInstance(_worldTransform);

            var spawnPosition = _enemyPositions.RandomSpawnPosition();
            enemy.transform.position = spawnPosition.position;

            var attackPosition = _enemyPositions.RandomAttackPosition();

            enemy.GetComponent<EnemyMoveAgent>().SetDestination(attackPosition.position);
            enemy.GetComponent<EnemyAttackAgent>().SetTarget(_character);
            return enemy;
        }

        public void UnspawnEnemy(Enemy enemy)
        {
            _pool.Release(enemy);
        }
    }
}