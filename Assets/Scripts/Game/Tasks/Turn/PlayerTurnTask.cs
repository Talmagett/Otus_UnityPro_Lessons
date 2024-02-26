using Game.TurnSystem;
using Game.TurnSystem.Events;
using Modules.Entities.Scripts;
using UnityEngine;

namespace Game.Tasks.Turn
{
    public sealed class PlayerTurnTask : Task
    {
        //private readonly KeyboardInput _input;
        private readonly IEntity _player;
        private readonly EventBus _eventBus;
        
        public PlayerTurnTask()
        {
        }
        
        protected override void OnRun()
        {
            //_input.MovePerformed += OnMovePreformed;
        }

        private void OnMovePreformed(Vector2Int direction)
        {
            //_input.MovePerformed -= OnMovePreformed;

            _eventBus.RaiseEvent(new ApplyDirectionEvent(_player, direction));
            Finish();
        }
    }
}