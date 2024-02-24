using Data.Variable;
using Entity.Components;
using UnityEngine;

namespace Logic.Mechanics
{
    public class MeleeAttackMechanics
    {
        private readonly IAtomicVariable<bool> _canAttack;
        private readonly IAtomicValue<int> _damage;

        public MeleeAttackMechanics(IAtomicValue<int> damage, IAtomicVariable<bool> canAttack)
        {
            _damage = damage;
            _canAttack = canAttack;
        }

        public void OnTriggerEnter(Collider collider)
        {
            if (!collider.TryGetComponent(out Entity.Entity entity)) return;

            if (!entity.TryComponent(out IComponent_Damagable damagable)) return;

            Debug.Log("Take Damage = " + _damage.Value);
            damagable.TakeDamage(_damage.Value);
        }
    }
}