using Data.Event;
using Model;
using UnityEngine;

namespace Logic.Mechanics.ShootMechanics
{
    public class ShootMechanics
    {
        private readonly Bullet _bullet;
        private readonly IAtomicEvent _fireEvent;
        private readonly Transform _firePoint;
        private readonly Transform _transform;

        public ShootMechanics(IAtomicEvent fireEvent, Transform firePoint, Bullet bullet, Transform transform)
        {
            _fireEvent = fireEvent;
            _firePoint = firePoint;
            _bullet = bullet;
            _transform = transform;
        }

        public void OnEnable()
        {
            _fireEvent.Subscribe(OnFire);
        }

        public void OnDisable()
        {
            _fireEvent.Unsubscribe(OnFire);
        }

        private void OnFire()
        {
            var bullet = Object.Instantiate(_bullet, _firePoint.position, _transform.rotation);
            bullet.Movement.MoveDirection.Value = _transform.forward;
        }
    }
}