using Game.TurnSystem.Events;

namespace Game.TurnSystem.Handlers
{
    public class ForceDirectionHandler : BaseHandler<ForceDirectionEvent>
    {
        public ForceDirectionHandler(EventBus eventBus) : base(eventBus)
        {
        }

        protected override void HandleEvent(ForceDirectionEvent evt)
        {
            /*
                var coordinates = evt.Entity.Get<CoordinatesComponent>();
                var targetCoordinates = coordinates.Value + evt.Direction;

                if (_levelMap.Entities.HasEntity(targetCoordinates))
                {
                    EventBus.RaiseEvent(new CollideEvent(evt.Entity, _levelMap.Entities.GetEntity(targetCoordinates)));
                }
                else
                {
                    EventBus.RaiseEvent(new MoveEvent(evt.Entity, targetCoordinates, true));
                }*/
        }
    }
}