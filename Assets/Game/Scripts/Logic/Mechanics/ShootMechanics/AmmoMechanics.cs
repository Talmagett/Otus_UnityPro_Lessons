using Data.Event;
using Data.Variable;
using Logic.Data;
using UnityEngine;

namespace Logic.Mechanics.ShootMechanics
{
    public class AmmoMechanics
    {
        private readonly AttackData _attackData;
        private readonly AtomicVariable<int> _bulletsDataCount;
        private readonly AtomicVariable<bool> _canShootTimer;

        public AmmoMechanics(AttackData attackData, AtomicVariable<int> bulletsDataCount, AtomicVariable<bool> canShootTimer)
        {
            _attackData = attackData;
            _bulletsDataCount = bulletsDataCount;
            _canShootTimer = canShootTimer;
        }

        public void OnEnable()
        {
            _attackData.AttackRequest.Subscribe(ReduceAmmo);
        }

        public void OnDisable()
        {
            _attackData.AttackRequest.Unsubscribe(ReduceAmmo);
        }

        private void ReduceAmmo()
        {
            if (!_attackData.CanAttack.Value) return;
            _canShootTimer.Value = false;
            _bulletsDataCount.Value--;
            _attackData.AttackEvent?.Invoke();
        }
    }
}