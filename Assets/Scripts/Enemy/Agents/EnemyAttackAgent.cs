using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyAttackAgent : MonoBehaviour
    {
        public delegate void FireHandler(BulletConfig bulletConfig, Vector2 position, Vector2 direction);

        public event FireHandler OnFire;

        [SerializeField] private WeaponComponent weaponComponent;
        [SerializeField] private EnemyMoveAgent moveAgent;
        [SerializeField] private float countdown;

        private HitPointsComponent _characterTarget;
        private float _currentTime;

        public void SetTarget(HitPointsComponent target)
        {
            _characterTarget = target;
        }

        public void Reset()
        {
            _currentTime = countdown;
        }

        private void FixedUpdate()
        {
            if (!moveAgent.IsReached) return;

            if (!_characterTarget.IsHitPointsExists()) return;

            _currentTime -= Time.fixedDeltaTime;
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
            OnFire?.Invoke(weaponComponent.BulletConfig, startPosition, direction);
        }
    }
}