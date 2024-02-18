using UnityEngine;

namespace Lessons.Lesson14_ModuleMechanics
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