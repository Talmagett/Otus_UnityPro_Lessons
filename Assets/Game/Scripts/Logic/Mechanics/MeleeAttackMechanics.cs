using Data.Variable;

namespace Logic.Mechanics
{
    public class MeleeAttackMechanics
    {
        private readonly IAtomicValue<int> _damage;
        private readonly IAtomicVariable<bool> _canAttack;

        public MeleeAttackMechanics(IAtomicValue<int> damage, IAtomicVariable<bool> canAttack)
        {
            _damage = damage;
            _canAttack = canAttack;
        }

        public void OnTriggerEnter()
        {
            
        }
    }
}