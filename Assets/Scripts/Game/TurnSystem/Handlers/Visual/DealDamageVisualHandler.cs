using Game.Tasks.Visual;
using Game.TurnSystem.Events;
using Game.Visual;

namespace Game.TurnSystem.Handlers.Visual
{
    public class DealDamageVisualHandler : BaseHandler<DealDamageEvent>
    {
        private readonly VisualPipeline _visualPipeline;

        public DealDamageVisualHandler(EventBus eventBus, VisualPipeline visualPipeline) : base(eventBus)
        {
            _visualPipeline = visualPipeline;
        }

        protected override void HandleEvent(DealDamageEvent evt)
        {
            _visualPipeline.AddTask(new DealDamageVisualTask(evt.Entity, 0.15f));
        }
    }
}