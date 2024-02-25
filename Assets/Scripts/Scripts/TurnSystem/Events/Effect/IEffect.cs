using Entities;

namespace Lessons.TurnSystem.Events.Effect
{
    public interface IEffect
    {
        public IEntity Source { get; set; }
        public IEntity Target { get; set; }
    }
}