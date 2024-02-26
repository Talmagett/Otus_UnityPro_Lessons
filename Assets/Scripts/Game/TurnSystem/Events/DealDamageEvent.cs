using Modules.Entities.Scripts;

namespace Game.TurnSystem.Events
{
    public readonly struct DealDamageEvent
    {
        public readonly IEntity Entity;
        public readonly int Damage;

        public DealDamageEvent(IEntity entity, int damage)
        {
            Entity = entity;
            Damage = damage;
        }
    }
}