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

        private async void OnTargetHeroClicked(HeroPresenter target)
        {
            var currentHero = _heroTurnController.CurrentHero;
            
            if (target.HeroModel.TryGet(out PlayerColor color)&&currentHero.HeroModel.TryGet(out PlayerColor movingColor))
            {
                    if (color.Value == movingColor.Value)
                        return;
            }

            await currentHero.HeroView.AnimateAttack(target.HeroView);

            _heroTurnController.TargetHeroClickPerformed -= OnTargetHeroClicked;
            currentHero.HeroModel.Attack(_eventBus,target);
            target.HeroModel.CounterAttack(_eventBus,currentHero);
            Finish();
            _heroTurnController.NextHeroTurn();
        }
    }
}