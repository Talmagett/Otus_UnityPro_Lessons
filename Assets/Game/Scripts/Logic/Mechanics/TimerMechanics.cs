using Data.Variable;
using UnityEngine;

namespace Logic.Mechanics
{
    public class TimerMechanics
    {
        private readonly AtomicVariable<float> _timer;
        private readonly AtomicVariable<float> _maxCooldown;
        private readonly AtomicVariable<bool> _isFinished;

        public TimerMechanics(AtomicVariable<float> timer, AtomicVariable<float> maxCooldown, AtomicVariable<bool> isFinished)
        {
            _timer = timer;
            _maxCooldown = maxCooldown;
            _isFinished = isFinished;
        }

        public void OnEnable()
        {
            _isFinished.ValueChanged += OnRefreshTimer;
        }

        public void OnDisable()
        {
            _isFinished.ValueChanged -= OnRefreshTimer;
        }

        private void OnRefreshTimer(bool obj)
        {
            _timer.Value = _maxCooldown.Value;
        }

        public void Update()
        {
            if (_isFinished.Value)
                return;

            _timer.Value -= Time.deltaTime;
            if (_timer.Value <= 0)
                _isFinished.Value = true;
        }
    }
}