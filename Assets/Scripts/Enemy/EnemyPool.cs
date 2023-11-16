using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyPool : PoolSystem<GameObject>
    {
        [Header("Spawn")]
        [SerializeField] private EnemyPositions enemyPositions;
        [SerializeField] private HitPointsComponent character;

        public GameObject SpawnEnemy()
        {
            var enemy = GetInstance();
            if (enemy is null) return null;

            enemy.transform.SetParent(worldTransform);

            var spawnPosition = enemyPositions.RandomSpawnPosition();
            enemy.transform.position = spawnPosition.position;

            var attackPosition = enemyPositions.RandomAttackPosition();
            enemy.GetComponent<EnemyMoveAgent>().SetDestination(attackPosition.position);

            enemy.GetComponent<EnemyAttackAgent>().SetTarget(character);
            return enemy;
        }

        public void UnspawnEnemy(GameObject enemy)
        {
            enemy.transform.SetParent(container);
            Release(enemy);
        }
    }
}