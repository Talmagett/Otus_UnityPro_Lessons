using Logic.Data;
using Model;
using UnityEngine;

namespace Logic.Mechanics.ShootMechanics
{
    public class ShootMechanics
    {
        private readonly AttackData _attackData;
        private readonly Bullet _bullet;
        private readonly Transform _firePoint;
        private readonly Transform _transform;

        public ShootMechanics(AttackData attackData, Transform firePoint, Bullet bullet, Transform transform)
        {
            _attackData = attackData;
            _firePoint = firePoint;
            _bullet = bullet;
            _transform = transform;
        }

        public void OnEnable()
        {
            _attackData.AttackEvent.Subscribe(OnFire);
        }

        public void OnDisable()
        {
            _attackData.AttackEvent.Unsubscribe(OnFire);
        }

        private void OnFire()
        {
            if (!_attackData.CanAttack.Value)
                return;
            var bullet = Object.Instantiate(_bullet, _firePoint.position, _transform.rotation);
            bullet.Movement.MoveDirection.Value = _transform.forward;
        }
    }
}