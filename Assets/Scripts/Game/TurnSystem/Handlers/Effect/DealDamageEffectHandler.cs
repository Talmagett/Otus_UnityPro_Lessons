using Game.Entities.Common.Components;
using Game.TurnSystem.Events;
using Game.TurnSystem.Events.Effect;

namespace Game.TurnSystem.Handlers.Effect
{
    public sealed class DealDamageEffectHandler : BaseHandler<DealDamageEffectEvent>
    {
        public DealDamageEffectHandler(EventBus eventBus) : base(eventBus)
        {
        }

        protected override void HandleEvent(DealDamageEffectEvent evt)
        {
            var damage = evt.extraDamage;

            if (evt.Source.TryGet(out AttackDamage attackDamage)) damage += attackDamage.Value;

            EventBus.RaiseEvent(new DealDamageEvent(evt.Target, damage));
        }
    }
}