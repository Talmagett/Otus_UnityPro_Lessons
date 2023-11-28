using System;
using Bullets;
using Enemy.Agents;
using GameManager;
using UnityEngine;

namespace Enemy
{
    public class Enemy : MonoBehaviour
    {
        private GameManager.GameManager _gameManager;
        private IGameListener[] _gameListeners;

        public void Construct(GameManager.GameManager gameManager, BulletSystem bulletSystem)
        {
            _gameManager = gameManager;
            _gameListeners = GetComponents<IGameListener>();
            if (gameObject.TryGetComponent(out EnemyAttackAgent enemyAttackAgent))
                enemyAttackAgent.Construct(bulletSystem);
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