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
        public EnemyAttackAgent EnemyAttackAgent { get; private set; }
        public EnemyMoveAgent EnemyMoveAgent { get; private set; }
        
        public void Construct(GameManager.GameManager gameManager, BulletSystem bulletSystem)
        {
            _gameManager = gameManager;
            EnemyMoveAgent = new EnemyMoveAgent(moveComponent,transform);
            EnemyAttackAgent = new EnemyAttackAgent(weaponComponent, bulletSystem,EnemyMoveAgent);
        }

        public void Initialize()
        {
            _gameManager.AddListener(EnemyAttackAgent);
            _gameManager.AddListener(EnemyMoveAgent);
        }

        public void Dispose()
        {
            _gameManager.RemoveListener(EnemyMoveAgent);
            _gameManager.RemoveListener(EnemyAttackAgent);
        }
    }
}