using System;
using Game.Entities.Common.Components;
using Game.TurnSystem;
using Modules.Entities.Scripts.MonoBehaviours;
using UnityEngine;
using Zenject;

namespace Game.Input
{
    public sealed class PlayerController : IInitializable, IDisposable
    {
        private readonly MouseInput _input;

        private readonly EventBus _eventBus;

        public PlayerController(MouseInput input, EventBus eventBus)
        {
            _input = input;
            _eventBus = eventBus;
        }
        
        void IInitializable.Initialize()
        {            
            _input.HeroClickPerformed += OnHeroClick;

        }
        
        void IDisposable.Dispose()
        {
            _input.HeroClickPerformed -= OnHeroClick;
        }

        private void OnHeroClick(MonoEntity hero)
        {
            if(hero.TryGet(out Health health))
                Debug.Log(health.Value);
            //_eventBus.RaiseEvent(new ApplyDirectionEvent(_player, direction));
        }
    }
}