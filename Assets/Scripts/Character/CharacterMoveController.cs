using System;
using Components;
using GameManager;
using Input;
using UnityEngine;
using Zenject;

namespace Character
{
    public class CharacterMoveController :
        IGameFixedUpdateListener,IDisposable
    {
        private readonly GameManager.GameManager _gameManager;
        private readonly MoveComponent _moveComponent;
        private readonly InputManager _inputManager;
        [Inject]
        public CharacterMoveController(GameManager.GameManager gameManager,InputManager inputManager,MoveComponent moveComponent)
        {
            _inputManager = inputManager;
            _moveComponent = moveComponent;
            _gameManager = gameManager;
            _gameManager.AddListener(this);
        }
        public void OnGameFixedUpdate(float deltaTime)
        {
            Move();
        }

        private void Move()
        {
            _moveComponent.Move(new Vector2(_inputManager.MoveDirection, 0) * Time.fixedDeltaTime);
        }

        public void Dispose()
        {
            _gameManager.RemoveListener(this);
        }
    }
}