using Data.Event;
using Data.Variable;
using Logic.Data;

namespace Logic.Mechanics.ShootMechanics
{
    public class AmmoRefillMechanics
    {
        private readonly TimerData _onRefillTimer;
        private readonly ResourceData _ammoResource;

        public AmmoRefillMechanics(ResourceData ammoResource, TimerData onRefillTimer)
        {
            _ammoResource = ammoResource;
            _onRefillTimer = onRefillTimer;
        }

        public void OnEnable()
        {
            _onRefillTimer.FinishEvent.Subscribe(Refill);
            _ammoResource.Count.ValueChanged += SetTimerOnOff;
        }

        public void OnDisable()
        {
            _onRefillTimer.FinishEvent.Unsubscribe(Refill);
            _ammoResource.Count.ValueChanged -= SetTimerOnOff;
        }
        
        private void SetTimerOnOff(int obj)
        {
            _onRefillTimer.CanCount.Value = !_ammoResource.IsFull;
        }
        
        private void Refill()
        {
            _ammoResource.Count.Value++;
        }
    }
}