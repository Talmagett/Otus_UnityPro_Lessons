using System;
using Game.Entities.Common.Components;
using Game.Installers;
using Game.TurnSystem;
using Game.TurnSystem.Events;
using Game.UI;
using Modules.Entities.Scripts;

namespace Game.Tasks.Turn
{
    public sealed class PlayerTurnTask : Task
    {
        private readonly EventBus _eventBus;
        private readonly HeroTurnController _heroTurnController;

        public PlayerTurnTask(EventBus eventBus, HeroTurnController heroTurnController)
        {
            _eventBus = eventBus;
            _heroTurnController = heroTurnController;
        }
        
        protected override void OnRun()
        {
            _heroTurnController.TargetHeroClickPerformed += OnTargetHeroClicked;
        }

        private void OnTargetHeroClicked(HeroPresenter target)
        {
            var currentHero = _heroTurnController.CurrentHero;
            
            if (target.HeroModel.TryGet(out PlayerColor color)&&currentHero.HeroModel.TryGet(out PlayerColor movingColor))
            {
                    if (color.Value == movingColor.Value)
                        return;
            }

            currentHero.HeroView.AnimateAttack(target.HeroView);
            var damage = currentHero.HeroModel.Get<AttackDamage>();

            _heroTurnController.TargetHeroClickPerformed -= OnTargetHeroClicked;
            _eventBus.RaiseEvent(new DealDamageEvent(target.HeroModel, damage.Value));
            Finish();
            _heroTurnController.NextHero();
        }
    }
}