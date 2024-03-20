using Logic.Data;
using UnityEngine;

namespace Logic.Mechanics.TimeMechanics
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

            if (_timer.AutoStart.Value)
                _timer.Finished.Value = false;
        }

        public void Update()
        {
            if (!_timer.CanCount.Value)
                return;

            if (_timer.AutoStart.Value)
            {
                _timer.TimerCounter.Value -= Time.deltaTime;
            }
            else
            {
                if (!_timer.Finished.Value)
                    _timer.TimerCounter.Value -= Time.deltaTime;
            }

            if (!(_timer.TimerCounter.Value <= 0))
                return;

            _timer.Finished.Value = true;
            _timer.FinishEvent.Invoke();
        }
    }
}