using Game.TurnSystem.Events.Effect;

namespace Game.TurnSystem.Handlers.Effect
{
    public sealed class PushEffectHandler : BaseHandler<PushEffectEvent>
    {
        public PushEffectHandler(EventBus eventBus) : base(eventBus)
        {
        }

        protected override void HandleEvent(PushEffectEvent evt)
        {
            //var coordinates = evt.Source.Get<CoordinatesComponent>();
            //var targetCoordinates = evt.Target.Get<CoordinatesComponent>();
            //var direction = targetCoordinates.Value - coordinates.Value;
            //EventBus.RaiseEvent(new ForceDirectionEvent(evt.Target, direction));
        }
    }
}