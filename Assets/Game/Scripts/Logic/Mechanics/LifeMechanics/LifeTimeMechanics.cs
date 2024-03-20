using Data.Event;
using Data.Variable;
using UnityEngine;

namespace Logic.Mechanics
{
    public class LifeTimeMechanics
    {
        private readonly IAtomicAction _death;
        private readonly IAtomicVariable<float> _lifeTime;

        public LifeTimeMechanics(IAtomicVariable<float> lifeTime, IAtomicAction death)
        {
            _lifeTime = lifeTime;
            _death = death;
        }

        public void Update()
        {
            _lifeTime.Value -= Time.deltaTime;

            if (_lifeTime.Value <= 0) _death.Invoke();
        }
    }
}