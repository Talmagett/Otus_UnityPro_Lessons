using Game.TurnSystem.Events;

namespace Game.TurnSystem.Handlers
{
    public sealed class ApplyDirectionHandler : BaseHandler<ApplyDirectionEvent>
    {
        public ApplyDirectionHandler(EventBus eventBus) : base(eventBus)
        {
        }

        protected override void HandleEvent(ApplyDirectionEvent evt)
        {
            /*
                var coordinates = evt.Entity.Get<CoordinatesComponent>();
                var targetCoordinates = coordinates.Value + evt.Direction;

                if (_levelMap.Entities.HasEntity(targetCoordinates))
                {
                    EventBus.RaiseEvent(new AttackEvent(evt.Entity, _levelMap.Entities.GetEntity(targetCoordinates)));
                    return;
                }

                if (_levelMap.Tiles.IsWalkable(targetCoordinates))
                {
                    EventBus.RaiseEvent(new MoveEvent(evt.Entity, targetCoordinates));
                }*/
        }
    }
}