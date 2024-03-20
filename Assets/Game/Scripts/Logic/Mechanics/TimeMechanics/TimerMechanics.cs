using Data.Variable;
using UnityEngine;

namespace Logic.Mechanics
{
    public class TimerMechanics
    {
        private readonly TimerData _timer;
        public TimerMechanics(TimerData timer)
        {
            _timer = timer;
        }

        public void OnEnable()
        {
            _timer.FinishEvent.Subscribe(RefreshTimer);
        }

        public void OnDisable()
        {
            _timer.FinishEvent.Unsubscribe(RefreshTimer);
        }

        private void RefreshTimer()
        {
            _timer.TimerCounter.Value = _timer.MaxTime.Value;
            _timer.Finished.Value = false;
        }

        public void Update()
        {
            if (!_timer.CanCount.Value)
                return;

            _timer.TimerCounter.Value -= Time.deltaTime;
            
            if (!(_timer.TimerCounter.Value <= 0)) 
                return;
            
            _timer.Finished.Value = true;
            _timer.FinishEvent.Invoke();
        }
    }
}