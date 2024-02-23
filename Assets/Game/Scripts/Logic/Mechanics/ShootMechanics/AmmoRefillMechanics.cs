using Data.Event;
using Data.Variable;

namespace Logic.Mechanics
{
    public class AmmoRefillMechanics
    {
        private readonly IAtomicVariable<int> _bulletsCount;
        private readonly IAtomicVariable<int> _bulletsMaxCount;
        private readonly IAtomicVariable<bool> _onRefilled;

        public AmmoRefillMechanics(IAtomicVariable<int> bulletsCount, IAtomicVariable<int> bulletsMaxCount,
            IAtomicVariable<bool> onRefilled)
        {
            _bulletsCount = bulletsCount;
            _bulletsMaxCount = bulletsMaxCount;
            _onRefilled = onRefilled;
        }

        public void Update()
        {
            if (_bulletsCount.Value >= _bulletsMaxCount.Value || !_onRefilled.Value) return;
            
            _bulletsCount.Value++;
            _onRefilled.Value = false;
        }
    }
}