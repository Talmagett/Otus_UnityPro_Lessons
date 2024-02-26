using Entities.Common.Components;
using TurnSystem.Events;
using TurnSystem.Events.Effect;

namespace TurnSystem.Handlers.Effect
{
    public sealed class DealDamageEffectHandler : BaseHandler<DealDamageEffectEvent>
    {
        public DealDamageEffectHandler(EventBus eventBus) : base(eventBus)
        {
            
        }
        
        protected override void HandleEvent(DealDamageEffectEvent evt)
        {
            var damage = evt.extraDamage;

            if (evt.Source.TryGet(out AttackDamage attackDamage))
            {
                damage += attackDamage.Value;
            }
            
            EventBus.RaiseEvent(new DealDamageEvent(evt.Target, damage));
        }
    }
}