using Lessons.Entities.Common.Components;
using Lessons.Level;
using Lessons.TurnSystem.Events;

namespace Lessons.TurnSystem.Handlers
{
    public sealed class ApplyDirectionHandler : BaseHandler<ApplyDirectionEvent>
    {
        private readonly LevelMap _levelMap;

        public ApplyDirectionHandler( EventBus eventBus, LevelMap levelMap) : base(eventBus)
        {
            _levelMap = levelMap;
        }
        
        protected override void HandleEvent(ApplyDirectionEvent evt)
        {
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
            }
        }
    }
}