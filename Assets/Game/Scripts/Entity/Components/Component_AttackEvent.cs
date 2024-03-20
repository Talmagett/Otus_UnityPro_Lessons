using Data.Event;

namespace Entity.Components
{
    public class Component_AttackEvent : IComponent_AttackEvent
    {
        private readonly IAtomicAction _attackEvent;

        public Component_AttackEvent(IAtomicAction attackAttackEvent)
        {
            _attackEvent = attackAttackEvent;
        }

        public void Attack()
        {
            _attackEvent?.Invoke();
        }
    }
}