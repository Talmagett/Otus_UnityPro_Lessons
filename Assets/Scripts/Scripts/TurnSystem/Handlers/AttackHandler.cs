using Lessons.Entities.Common.Components;
using Lessons.TurnSystem.Events;

namespace Lessons.TurnSystem.Handlers
{
    public sealed class AttackHandler : BaseHandler<AttackEvent>
    {
        public AttackHandler(EventBus eventBus) : base(eventBus)
        {
            
        }
        
        protected override void HandleEvent(AttackEvent evt)
        {
            if (!evt.Entity.TryGet(out WeaponComponent weapon))
            {
                return;
            }
            
            foreach (var effect in weapon.Value.Effects)
            {
                effect.Source = evt.Entity;
                effect.Target = evt.Target;
                EventBus.RaiseEvent(effect);
            }
        }
    }
}