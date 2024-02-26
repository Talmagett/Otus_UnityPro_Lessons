using Modules.Entities.Scripts;

namespace Game.TurnSystem.Events
{
    public readonly struct AttackEvent
    {
        public readonly IEntity Entity;
        public readonly IEntity Target;

        public AttackEvent(IEntity entity, IEntity target)
        {
            Entity = entity;
            Target = target;
        }
    }
}