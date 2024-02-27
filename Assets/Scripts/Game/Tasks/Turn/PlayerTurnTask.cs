using System;
using Game.Entities.Common.Components;
using Game.Installers;
using Game.TurnSystem;
using Game.TurnSystem.Events;
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
            _heroTurnController.HeroClickPerformed += OnHeroClicked;
        }

        private void OnHeroClicked(IEntity entity)
        {
            var currentHero = _heroTurnController.CurrentHero;
            
            if (entity.TryGet(out PlayerColor color)&&currentHero.TryGet(out PlayerColor movingColor))
            {
                    if (color.Value == movingColor.Value)
                        return;
            }

            var damage = currentHero.Get<AttackDamage>();

            _heroTurnController.HeroClickPerformed -= OnHeroClicked;
            _eventBus.RaiseEvent(new DealDamageEvent(entity, damage.Value));
            Finish();
            _heroTurnController.NextHero();
        }
    }
}