using Data.Variable;
using Entity.Components;
using Logic.Data;
using UnityEngine;

namespace Logic.Mechanics
{
    public class MeleeAttackMechanics
    {
        private readonly AttackData _attack;
        private readonly Entity.Entity _attacker;

        public MeleeAttackMechanics(AttackData attack,Entity.Entity attacker)
        {
            _attack = attack;
            _attacker = attacker;
        }

        public void OnTriggerEnter(Collider collider)
        {
            if (!collider.TryGetComponent(out Entity.Entity entity)) return;
            if (_attacker.GetType() == entity.GetType()) return;
            if (!entity.TryComponent(out IComponent_Damagable damagable)) return;

            damagable.TakeDamage(_attack.Damage.Value);
        }
    }
}