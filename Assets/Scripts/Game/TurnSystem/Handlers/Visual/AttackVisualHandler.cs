using Game.Entities.Common.Components;
using Game.Tasks.Visual;
using Game.TurnSystem.Events;
using Game.Visual;

namespace Game.TurnSystem.Handlers.Visual
{
    public sealed class AttackVisualHandler : BaseHandler<AttackEvent>
    {
        private readonly VisualPipeline _visualPipeline;

        public AttackVisualHandler(EventBus eventBus, VisualPipeline visualPipeline) : base(eventBus)
        {
            _visualPipeline = visualPipeline;
        }

        protected override void HandleEvent(AttackEvent evt)
        {
            var sourcePosition = evt.Entity.Get<PositionComponent>();
            var targetPosition = evt.Target.Get<PositionComponent>();
            var offset = (targetPosition.Value - sourcePosition.Value) * 0.5f;

            _visualPipeline.AddTask(new MoveVisualTask(evt.Entity, sourcePosition.Value + offset, 0.15f));
            _visualPipeline.AddTask(new MoveVisualTask(evt.Entity, sourcePosition.Value, 0.15f));
        }
    }
}