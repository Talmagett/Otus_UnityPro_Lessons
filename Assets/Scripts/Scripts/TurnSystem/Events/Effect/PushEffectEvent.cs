using System;
using Entities;

namespace Lessons.TurnSystem.Events.Effect
{
    [Serializable]
    public struct PushEffectEvent : IEffect
    {
        public IEntity Source { get; set; }
        public IEntity Target { get; set; }
    }
}