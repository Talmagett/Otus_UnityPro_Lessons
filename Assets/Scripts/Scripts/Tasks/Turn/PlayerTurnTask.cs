using Entities;
using Lessons.Game;
using Lessons.Game.Services;
using Lessons.TurnSystem;
using Lessons.TurnSystem.Events;
using UnityEngine;

namespace Lessons.Tasks.Turn
{
    public sealed class PlayerTurnTask : Task
    {
        private readonly KeyboardInput _input;
        private readonly IEntity _player;
        private readonly EventBus _eventBus;
        
        public PlayerTurnTask(KeyboardInput input, EventBus eventBus, PlayerService playerService)
        {
            _input = input;
            _player = playerService.Player;
            _eventBus = eventBus;
        }
        
        protected override void OnRun()
        {
            _input.MovePerformed += OnMovePreformed;
        }

        private void OnMovePreformed(Vector2Int direction)
        {
            _input.MovePerformed -= OnMovePreformed;

            _eventBus.RaiseEvent(new ApplyDirectionEvent(_player, direction));
            Finish();
        }
    }
}