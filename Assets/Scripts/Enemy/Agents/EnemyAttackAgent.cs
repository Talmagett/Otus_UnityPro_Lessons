using Bullets;
using Components;
using GameManager;
using UnityEngine;

namespace Enemy.Agents
{
    public sealed class EnemyAttackAgent : MonoBehaviour,
        IGameFixedUpdateListener
    {
        [SerializeField] private WeaponComponent weaponComponent;
        [SerializeField] private EnemyMoveAgent moveAgent;
        [SerializeField] private float countdown;

        private HitPointsComponent _characterTarget;
        private float _currentTime;
        private BulletSystem _bulletSystem;

        public void Construct(BulletSystem bulletSystem)
        {
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
            var startPosition = weaponComponent.Position;
            var vector = (Vector2)_characterTarget.transform.position - startPosition;
            var direction = vector.normalized;

            _bulletSystem.SpawnBullet(new BulletSystem.Args
            {
                isPlayer = false,
                physicsLayer = (int)weaponComponent.BulletConfig.physicsLayer,
                color = weaponComponent.BulletConfig.color,
                damage = weaponComponent.BulletConfig.damage,
                position = startPosition,
                velocity = direction * weaponComponent.BulletConfig.speed
            });
        }
    }
}