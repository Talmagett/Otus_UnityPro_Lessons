using System;
using Modules.Entities.Scripts;

namespace Game.TurnSystem.Events.Effect
{
    [Serializable]
    public struct PushEffectEvent : IEffect
    {
        public IEntity Source { get; set; }
        public IEntity Target { get; set; }
    }
}