using Data.Variable;

namespace Logic.Mechanics.ShootMechanics
{
    public class CanShootMechanics
    {
        private readonly IAtomicVariable<int> _bulletsCount;
        private readonly IAtomicVariable<bool> _canShoot;
        private readonly IAtomicVariable<bool> _isCooldownFinished;

        public CanShootMechanics(IAtomicVariable<bool> canShoot, IAtomicVariable<int> bulletsCount,
            IAtomicVariable<bool> isCooldownFinished)
        {
            _canShoot = canShoot;
            _bulletsCount = bulletsCount;
            _isCooldownFinished = isCooldownFinished;
        }

        public void OnEnable()
        {
            _bulletsCount.ValueChanged += OnBulletsCountChanged;
            _isCooldownFinished.ValueChanged += OnIsCooldownFinishedChanged;
        }

        public void OnDisable()
        {
            _bulletsCount.ValueChanged -= OnBulletsCountChanged;
            _isCooldownFinished.ValueChanged -= OnIsCooldownFinishedChanged;
        }

        private void OnBulletsCountChanged(int count)
        {
            CheckCanShoot();
        }

        private void OnIsCooldownFinishedChanged(bool obj)
        {
            CheckCanShoot();
        }

        private void CheckCanShoot()
        {
            _canShoot.Value = _bulletsCount.Value > 0 && _isCooldownFinished.Value;
        }
    }
}