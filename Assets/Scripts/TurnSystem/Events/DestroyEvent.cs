using Modules.Entities.Scripts;

namespace TurnSystem.Events
{
    public readonly struct DestroyEvent
    {
        public readonly IEntity Entity;

        public DestroyEvent(IEntity entity)
        {
            Entity = entity;
        }
    }
}