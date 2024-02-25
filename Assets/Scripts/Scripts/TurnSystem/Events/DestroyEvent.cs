using Entities;

namespace Lessons.TurnSystem.Events
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