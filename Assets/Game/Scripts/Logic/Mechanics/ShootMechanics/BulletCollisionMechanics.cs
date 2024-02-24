using Data.Event;
using Data.Variable;
using Entity.Components;
using UnityEngine;

namespace Logic.Mechanics.ShootMechanics
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
            if (!collider.TryGetComponent(out Entity.Entity entity)) return;

            if (!entity.TryComponent(out IComponent_Damagable damagable)) return;

            Debug.Log("Take Damage = " + _damage.Value);
            damagable.TakeDamage(_damage.Value);
            _death.Invoke();
        }
    }
}