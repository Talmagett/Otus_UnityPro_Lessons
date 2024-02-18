using UnityEngine;

namespace Lessons.Lesson14_ModuleMechanics
{
    public class TakeDamageMechanics
    {
        private readonly IAtomicVariable<int> _hitPoints;
        private readonly IAtomicEvent<int> _takeDamage;
        private readonly IAtomicAction _death;

        public TakeDamageMechanics(IAtomicVariable<int> hitPoints, IAtomicEvent<int> takeDamage, IAtomicAction death)
        {
            _hitPoints = hitPoints;
            _takeDamage = takeDamage;
            _death = death;
        }

        public void OnEnable()
        {
            _takeDamage.Subscribe(OnTakeDamage);
        }
        
        public void OnDisable()
        {
            _takeDamage.Unsubscribe(OnTakeDamage);
        }

        private void OnTakeDamage(int damage)
        {
            var hitPoint = _hitPoints.Value - damage;
            _hitPoints.Value = Mathf.Max(0, hitPoint);

            if (_hitPoints.Value == 0)
            {
                _death?.Invoke();
            }
        }
    }
}