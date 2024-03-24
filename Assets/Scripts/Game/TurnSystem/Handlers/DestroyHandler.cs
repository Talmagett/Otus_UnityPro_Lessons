using Game.Entities.Common.Components;
using Game.Installers;
using Game.TurnSystem.Events;
using Game.UI;

namespace Game.TurnSystem.Handlers
{
    public sealed class DestroyHandler : BaseHandler<DestroyEvent>
    {
        private readonly HeroTurnController _heroTurnController;

        public DestroyHandler(EventBus eventBus,HeroTurnController heroTurnController) : base(eventBus)
        {
            _heroTurnController = heroTurnController;
        }

        protected override void HandleEvent(DestroyEvent evt)
        {
            _heroTurnController.DestroyHero(evt.Entity.Get<HeroPresenter>());
        }
    }
}