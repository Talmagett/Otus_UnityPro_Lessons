using Game.Entities.Common.Components;
using Game.Entities.Config;
using Game.TurnSystem.Events;
using Game.TurnSystem.Events.Effect;
using UnityEngine;

namespace Game.TurnSystem.Handlers
{
    public sealed class DealDamageHandler : BaseHandler<DealDamageEvent>
    {
        public DealDamageHandler(EventBus eventBus) : base(eventBus)
        {
        }

        protected override void HandleEvent(DealDamageEvent evt)
        {
            if (!evt.Entity.TryGet(out Health health))
                return;
            if (evt.Entity.TryGet(out Ability ability))
            {
                foreach (var effect in ability.Effects)
                {
                    if (effect is DivineShieldEffectEvent)
                        return;
                }
            }
            var prevHealth = health.Value;
            health.Value -= evt.Damage;
            if (health.Value <= 0) EventBus.RaiseEvent(new DestroyEvent(evt.Entity));
        }
    }
}