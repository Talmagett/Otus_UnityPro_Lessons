using System;
using Entities;
using Entities.Common.Components;
using Entities.Heroes;
using Game;
using Modules.Entities.Scripts;
using Modules.Entities.Scripts.MonoBehaviours;
using TurnSystem;
using TurnSystem.Events;
using UnityEngine;
using Zenject;

namespace Lessons.Game
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