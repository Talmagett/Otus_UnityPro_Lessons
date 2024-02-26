using Game.Entities.Common.Components;
using Game.TurnSystem.Events;

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
            
            health.Value -= evt.Damage;

            if (health.Value <= 0)
            {
                EventBus.RaiseEvent(new DestroyEvent(evt.Entity));
            }
        }
    }
}