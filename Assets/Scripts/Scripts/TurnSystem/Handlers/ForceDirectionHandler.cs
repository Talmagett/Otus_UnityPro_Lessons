using Lessons.Entities.Common.Components;
using Lessons.Level;
using Lessons.TurnSystem.Events;

namespace Lessons.TurnSystem.Handlers
{
    public class ForceDirectionHandler : BaseHandler<ForceDirectionEvent>
    {
        private readonly LevelMap _levelMap;

        public ForceDirectionHandler(LevelMap levelMap, EventBus eventBus) : base(eventBus)
        {
            _levelMap = levelMap;
        }

        protected override void HandleEvent(ForceDirectionEvent evt)
        {
            var coordinates = evt.Entity.Get<CoordinatesComponent>();
            var targetCoordinates = coordinates.Value + evt.Direction;

            if (_levelMap.Entities.HasEntity(targetCoordinates))
            {
                EventBus.RaiseEvent(new CollideEvent(evt.Entity, _levelMap.Entities.GetEntity(targetCoordinates)));
            }
            else
            {
                EventBus.RaiseEvent(new MoveEvent(evt.Entity, targetCoordinates, true));
            }
        }
    }
}