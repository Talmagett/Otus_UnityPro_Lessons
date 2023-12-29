using System;
using Bullets;
using Components;
using Enemy.Agents;
using GameManager;
using UnityEngine;

namespace Enemy
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private WeaponComponent weaponComponent;
        [SerializeField] private MoveComponent moveComponent;
        
        private GameManager.GameManager _gameManager;
        private IGameListener[] _gameListeners;
        private EnemyAttackAgent _enemyAttackAgent;
        private EnemyMoveAgent _enemyMoveAgent;
        public void Construct(GameManager.GameManager gameManager, BulletSystem bulletSystem)
        {
            _gameManager = gameManager;
            _gameListeners = GetComponents<IGameListener>();
            _enemyAttackAgent = new EnemyAttackAgent(weaponComponent, bulletSystem);
            _enemyMoveAgent = new EnemyMoveAgent(moveComponent,transform);
        }

        public void Initialize()
        {
            _gameManager.AddListeners(_gameListeners);
        }

        public void Dispose()
        {
            _gameManager.RemoveListeners(_gameListeners);
        }
    }
}