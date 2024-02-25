using Lessons.Entities.Common.Components;
using Lessons.TurnSystem.Events;
using Lessons.TurnSystem.Events.Effect;

namespace Lessons.TurnSystem.Handlers.Effect
{
    public sealed class PushEffectHandler : BaseHandler<PushEffectEvent>
    {
        public PushEffectHandler(EventBus eventBus) : base(eventBus)
        {
            
        }
        
        protected override void HandleEvent(PushEffectEvent evt)
        {
            var coordinates = evt.Source.Get<CoordinatesComponent>();
            var targetCoordinates = evt.Target.Get<CoordinatesComponent>();
            var direction = targetCoordinates.Value - coordinates.Value;
            //EventBus.RaiseEvent(new ForceDirectionEvent(evt.Target, direction));
        }
    }
}