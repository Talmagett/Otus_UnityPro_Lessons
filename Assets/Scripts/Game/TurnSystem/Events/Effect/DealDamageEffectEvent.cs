using System;
using Modules.Entities.Scripts;

namespace Game.TurnSystem.Events.Effect
{
    [Serializable]
    public struct DealDamageEffectEvent : IEffect
    {
        public int extraDamage;
        public IEntity Source { get; set; }
        public IEntity Target { get; set; }
    }
}