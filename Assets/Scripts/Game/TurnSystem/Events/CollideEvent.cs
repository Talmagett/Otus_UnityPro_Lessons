using Modules.Entities.Scripts;

namespace Game.TurnSystem.Events
{
    public readonly struct CollideEvent
    {
        public readonly IEntity Entity;
        public readonly IEntity Target;

        public CollideEvent(IEntity entity, IEntity target)
        {
            Entity = entity;
            Target = target;
        }
    }
}