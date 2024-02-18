using Data.Event;
using Data.Variable;
using UnityEngine;

namespace Logic
{
    public class LifeTimeMechanics
    {
        private readonly IAtomicVariable<float> _lifeTime;
        private readonly IAtomicAction _death;

        public LifeTimeMechanics(IAtomicVariable<float> lifeTime, IAtomicAction death)
        {
            _lifeTime = lifeTime;
            _death = death;
        }

        public void Update()
        {
            _lifeTime.Value -= Time.deltaTime;
            
            if (_lifeTime.Value <= 0)
            {
                _death.Invoke();
            }
        }
    }
}