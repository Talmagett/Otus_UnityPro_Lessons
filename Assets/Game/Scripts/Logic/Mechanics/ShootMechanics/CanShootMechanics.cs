using Data.Variable;

namespace Logic.Mechanics
{
    public class CanShootMechanics
    {
        private readonly IAtomicVariable<int> _bulletsCount;
        private readonly IAtomicVariable<bool> _canShoot;

        public CanShootMechanics(IAtomicVariable<int> bulletsCount, IAtomicVariable<bool> canShoot)
        {
            _bulletsCount = bulletsCount;
            _canShoot = canShoot;
        }

        public void Update()
        {
            _canShoot.Value = _bulletsCount.Value > 0;
        }
    }
}