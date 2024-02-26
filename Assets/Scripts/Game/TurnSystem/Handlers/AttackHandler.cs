using Game.Entities.Common.Components;
using Game.TurnSystem.Events;

namespace Game.TurnSystem.Handlers
{
    public sealed class AttackHandler : BaseHandler<AttackEvent>
    {
        public AttackHandler(EventBus eventBus) : base(eventBus)
        {
            
        }
        
        protected override void HandleEvent(AttackEvent evt)
        {
            if (!evt.Entity.TryGet(out AttackDamage weapon))
            {
                return;
            }
            /*TODO:??
            foreach (var effect in weapon.Value.Effects)
            {
                effect.Source = evt.Entity;
                effect.Target = evt.Target;
                EventBus.RaiseEvent(effect);
            }*/
        }
    }
}