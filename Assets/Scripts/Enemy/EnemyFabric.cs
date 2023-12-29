using Bullets;
using Common;
using Components;
using UnityEngine;
using Zenject;

namespace Enemy
{
    public sealed class EnemyFabric
    {
        private readonly GameManager.GameManager _gameManager;

        private readonly EnemyPositions _enemyPositions;
        private readonly HitPointsComponent _character;
        private readonly Pool<Enemy> _pool;
        private readonly BulletSystem _bulletSystem;

        private readonly Transform _worldTransform;
        
        [Inject]
        public EnemyFabric(GameManager.GameManager gameManager,EnemyPositions enemyPositions, HitPointsComponent character,
            PoolArgs<Enemy> enemyPoolArgs, BulletSystem bulletSystem)
        {
            _enemyPositions = enemyPositions;
            _character = character;
            _worldTransform = enemyPoolArgs.WorldTransform;
            _gameManager = gameManager;
            _bulletSystem = bulletSystem;
            _pool = new Pool<Enemy>(enemyPoolArgs.Prefab,enemyPoolArgs.Container,enemyPoolArgs.InitialCount);
        }

        public Enemy SpawnEnemy()
        {
            var enemy = _pool.GetInstance(_worldTransform);

            var spawnPosition = _enemyPositions.RandomSpawnPosition();
            enemy.transform.position = spawnPosition.position;

            var attackPosition = _enemyPositions.RandomAttackPosition();

            enemy.Construct(_gameManager, _bulletSystem,_character,attackPosition.position);

            return enemy;
        }

        public void UnspawnEnemy(Enemy enemy)
        {
            _pool.Release(enemy);
        }
    }
}