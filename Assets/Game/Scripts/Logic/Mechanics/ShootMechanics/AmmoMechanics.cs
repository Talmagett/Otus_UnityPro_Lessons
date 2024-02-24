using Data.Event;
using Data.Variable;

namespace Logic.Mechanics.ShootMechanics
{
    public class AmmoMechanics
    {
        private readonly IAtomicVariable<int> _bulletsCount;
        private readonly IAtomicValue<bool> _canShoot;
        private readonly IAtomicEvent _fireEvent;
        private readonly IAtomicEvent _fireRequest;

        public AmmoMechanics(IAtomicEvent fireRequest, IAtomicVariable<int> bulletsCount, IAtomicValue<bool> canShoot,
            IAtomicEvent fireEvent)
        {
            _fireRequest = fireRequest;
            _bulletsCount = bulletsCount;
            _canShoot = canShoot;
            _fireEvent = fireEvent;
        }

        public void OnEnable()
        {
            _fireRequest.Subscribe(ReduceAmmo);
        }

        public void OnDisable()
        {
            _fireRequest.Unsubscribe(ReduceAmmo);
        }

        private void ReduceAmmo()
        {
            if (_canShoot.Value)
            {
                _bulletsCount.Value--;
                _fireEvent?.Invoke();
            }
        }
    }
}