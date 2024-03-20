using Data.Variable;
using Logic.Data;

namespace Logic.Mechanics.ShootMechanics
{
    public class AmmoMechanics
    {
        private readonly AttackData _attackData;
        private readonly AtomicVariable<int> _bulletsCount;
        private readonly AtomicVariable<bool> _canShootTimer;

        public AmmoMechanics(AttackData attackData, AtomicVariable<int> bulletsCount,
            AtomicVariable<bool> canShootTimer)
        {
            _attackData = attackData;
            _bulletsCount = bulletsCount;
            _canShootTimer = canShootTimer;
        }

        public void OnEnable()
        {
            _attackData.AttackEvent.Subscribe(ReduceAmmo);
        }

        public void OnDisable()
        {
            _attackData.AttackEvent.Unsubscribe(ReduceAmmo);
        }

        private void ReduceAmmo()
        {
            if (!_attackData.CanAttack.Value) return;
            _canShootTimer.Value = false;
            _bulletsCount.Value--;
        }
    }
}