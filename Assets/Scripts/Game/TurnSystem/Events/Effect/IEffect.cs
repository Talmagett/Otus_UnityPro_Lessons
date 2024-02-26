using Modules.Entities.Scripts;

namespace Game.TurnSystem.Events.Effect
{
    public interface IEffect
    {
        public IEntity Source { get; set; }
        public IEntity Target { get; set; }
    }
}