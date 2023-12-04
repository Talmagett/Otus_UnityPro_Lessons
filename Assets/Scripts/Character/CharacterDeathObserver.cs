using System;
using Components;
using GameManager;
using UnityEngine;
using Zenject;

namespace Character
{
    public class CharacterDeathObserver :
        IGameStartListener, 
        IGameFinishListener, 
        IGamePauseListener, 
        IGameResumeListener,
        IDisposable
    {
        private readonly GameManager.GameManager _gameManager;
        private readonly HitPointsComponent _hitPointsComponent;
        
        [Inject]
        public CharacterDeathObserver(GameManager.GameManager gameManager, HitPointsComponent hitPointsComponent)
        {
            _gameManager = gameManager;
            _hitPointsComponent = hitPointsComponent;
            _gameManager.AddListener(this);
        }

        private void OnCharacterDeath(GameObject _)
        {
            _gameManager.FinishGame();
        }

        public void OnGameStart()
        {
            _hitPointsComponent.OnHitPointsEmpty += OnCharacterDeath;
        }

        public void OnGameFinish()
        {
            _hitPointsComponent.OnHitPointsEmpty -= OnCharacterDeath;
        }

        public void OnGamePause()
        {
            _hitPointsComponent.OnHitPointsEmpty -= OnCharacterDeath;
        }

        public void OnGameResume()
        {
            _hitPointsComponent.OnHitPointsEmpty += OnCharacterDeath;
        }

        public void Dispose()
        {
            _gameManager.RemoveListener(this);            
        }
    }
}