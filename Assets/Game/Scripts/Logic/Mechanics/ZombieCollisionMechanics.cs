using Data.Event;
using Data.Variable;
using Entity.Components;
using Model;
using UnityEngine;

namespace Logic.Mechanics
{
    public class ZombieCollisionMechanics
    {
        private readonly IAtomicValue<int> _damage;
        private readonly IAtomicAction _death;

        public ZombieCollisionMechanics(IAtomicValue<int> damage, IAtomicAction death)
        {
            _damage = damage;
            _death = death;
        }

        public void OnTriggerEnter(Collider collider)
        {
            if (!collider.TryGetComponent(out Character character)) return;
            if (!character.TryGetComponent(out Entity.Entity entity)) return;

            if (!entity.TryComponent(out IComponent_Damagable damagable)) return;
            
            Debug.Log("Take Damage = " + _damage.Value);
            damagable.TakeDamage(_damage.Value);
            _death.Invoke();
        }
    }
}