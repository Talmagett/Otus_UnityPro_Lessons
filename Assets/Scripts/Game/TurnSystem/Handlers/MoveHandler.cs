using Game.TurnSystem.Events;

namespace Game.TurnSystem.Handlers
{
    public sealed class MoveHandler : BaseHandler<MoveEvent>
    {
        public MoveHandler(EventBus eventBus) : base(eventBus)
        {
        }

        protected override void HandleEvent(MoveEvent evt)
        {
            /*
                var coordinates = evt.Entity.Get<CoordinatesComponent>();

                _levelMap.Entities.RemoveEntity(coordinates.Value);
                _levelMap.Entities.SetEntity(evt.Coordinates, evt.Entity);
                coordinates.Value = evt.Coordinates;
    */
            // // Visual
            // var position = evt.Entity.Get<PositionComponent>();
            // position.Value = _levelMap.Tiles.CoordinatesToPosition(evt.Coordinates);
            //
            /*if (!_levelMap.Tiles.IsWalkable(evt.Coordinates))
            {
                EventBus.RaiseEvent(new DestroyEvent(evt.Entity));
            }*/
        }
    }
}