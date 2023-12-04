using System;
using Bullets;
using Components;
using GameManager;
using Input;
using UnityEngine;
using Zenject;

namespace Character
{
    public sealed class CharacterAttackController :
        IGameStartListener,
        IGameFinishListener,
        IGamePauseListener,
        IGameResumeListener,
        IDisposable
    {
        private readonly GameManager.GameManager _gameManager;
        private readonly InputManager _inputManager;
        private readonly BulletSystem _bulletSystem;
        private readonly WeaponComponent _weaponComponent;
        
        [Inject]
        public CharacterAttackController(GameManager.GameManager gameManager,InputManager inputManager,BulletSystem bulletSystem,WeaponComponent weaponComponent)
        {
            _gameManager = gameManager;
            _inputManager = inputManager;
            _bulletSystem = bulletSystem;
            _weaponComponent = weaponComponent;
            
            _gameManager.AddListener(this);
        }

        private void OnFire()
        {
            _bulletSystem.SpawnBullet(new BulletArgs
            {
                isPlayer = true,
                physicsLayer = (int)_weaponComponent.BulletConfig.physicsLayer,
                color = _weaponComponent.BulletConfig.color,
                damage = _weaponComponent.BulletConfig.damage,
                position = _weaponComponent.Position,
                velocity = _weaponComponent.Rotation * Vector3.up * _weaponComponent.BulletConfig.speed
            });
        }

        public void OnGameStart()
        {
            _inputManager.OnFire += OnFire;
        }

        public void OnGameFinish()
        {
            _inputManager.OnFire -= OnFire;
        }

        public void OnGamePause()
        {
            _inputManager.OnFire -= OnFire;
        }

        public void OnGameResume()
        {
            _inputManager.OnFire += OnFire;
        }

        public void Dispose()
        {
            _gameManager.RemoveListener(this);
        }
    }
}