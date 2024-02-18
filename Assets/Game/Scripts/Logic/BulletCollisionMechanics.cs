using UnityEngine;

namespace Lessons.Lesson14_ModuleMechanics
{
    public class BulletCollisionMechanics
    {
        private readonly IAtomicValue<int> _damage;
        private readonly IAtomicAction _death;

        public BulletCollisionMechanics(IAtomicValue<int> damage, IAtomicAction death)
        {
            _damage = damage;
            _death = death;
        }

        public void OnTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent(out Character character))
            {
                Debug.Log("Take Damage = " + _damage.Value);
                character.TakeDamage.Invoke(_damage.Value);
                _death.Invoke();
            }
        }
    }
}