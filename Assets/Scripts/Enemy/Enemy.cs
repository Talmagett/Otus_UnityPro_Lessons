using Bullets;
using Components;
using Enemy.Agents;
using UnityEngine;

namespace Enemy
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private WeaponComponent weaponComponent;
        [SerializeField] private MoveComponent moveComponent;
        
        private EnemyAttackAgent _enemyAttackAgent;
        private EnemyMoveAgent _enemyMoveAgent;
        
        private EnemyMoveAttackController _enemyMoveAttackController;
        
        public void Construct(GameManager.GameManager gameManager, BulletSystem bulletSystem,HitPointsComponent character, Vector3 attackPositionPosition)
        {
            _enemyMoveAgent = new EnemyMoveAgent(moveComponent,transform);
            _enemyAttackAgent = new EnemyAttackAgent(weaponComponent, bulletSystem);
            _enemyMoveAgent.SetDestination(attackPositionPosition);
            _enemyAttackAgent.SetTarget(character);
            _enemyMoveAttackController = new EnemyMoveAttackController(gameManager, _enemyAttackAgent, _enemyMoveAgent);
        }

        public void Initialize()
        {
            _enemyMoveAttackController.Initialize();
        }

        public void Dispose()
        {
            _enemyMoveAttackController.Dispose();
        }
    }
}