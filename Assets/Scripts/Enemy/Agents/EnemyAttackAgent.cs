using Bullets;
using Components;
using GameManager;
using UnityEngine;

namespace Enemy.Agents
{
    public sealed class EnemyAttackAgent :
        IGameFixedUpdateListener
    {
        private readonly WeaponComponent _weaponComponent;
        private EnemyMoveAgent moveAgent;
        private float countdown;

        private HitPointsComponent _characterTarget;
        private float _currentTime;
        private BulletSystem _bulletSystem;

        public EnemyAttackAgent(WeaponComponent weaponComponent,BulletSystem bulletSystem)
        {
            _weaponComponent = weaponComponent;
            _bulletSystem = bulletSystem;
        }

        public void SetTarget(HitPointsComponent target)
        {
            _characterTarget = target;
        }

        public void Reset()
        {
            _currentTime = countdown;
        }

        public void OnGameFixedUpdate(float deltaTime)
        {
            if (!moveAgent.IsReached) return;

            if (!_characterTarget.IsHitPointsExists()) return;

            _currentTime -= deltaTime;
            if (_currentTime <= 0)
            {
                Fire();
                _currentTime += countdown;
            }
        }

        private void Fire()
        {
            var startPosition = _weaponComponent.Position;
            var vector = (Vector2)_characterTarget.transform.position - startPosition;
            var direction = vector.normalized;

            _bulletSystem.SpawnBullet(new BulletArgs
            {
                isPlayer = false,
                physicsLayer = (int)_weaponComponent.BulletConfig.physicsLayer,
                color = _weaponComponent.BulletConfig.color,
                damage = _weaponComponent.BulletConfig.damage,
                position = startPosition,
                velocity = direction * _weaponComponent.BulletConfig.speed
            });
        }
    }
}