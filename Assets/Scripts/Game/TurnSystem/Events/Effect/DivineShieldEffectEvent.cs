using Modules.Entities.Scripts;

namespace Game.TurnSystem.Events.Effect
{
    [System.Serializable]
    public struct DivineShieldEffectEvent : IEffect
    {
        public IEntity Source { get; set; }
        public IEntity Target { get; set; }
    }
}