using Modules.Entities.Scripts;
using UnityEngine;

namespace Game.TurnSystem.Events.Effect
{
    [System.Serializable]
    public struct VampirismEffectEvent : IEffect
    {
        [field: SerializeField] public float Probability { get; private set; }
        public IEntity Source { get; set; }
        public IEntity Target { get; set; }
    }
}