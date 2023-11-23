using GameManager;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class CharacterAttackController : MonoBehaviour,IGameStartListener,IGameFinishListener,IGamePauseListener,IGameResumeListener
    {
        [SerializeField] private BulletSystem bulletSystem;
        [SerializeField] private InputManager inputManager;

        [Space] 
        [SerializeField] private WeaponComponent weaponComponent;

        private void OnFire()
        {
            bulletSystem.SpawnBullet(new BulletSystem.Args
            {
                isPlayer = true,
                physicsLayer = (int)weaponComponent.BulletConfig.physicsLayer,
                color = weaponComponent.BulletConfig.color,
                damage = weaponComponent.BulletConfig.damage,
                position = weaponComponent.Position,
                velocity = weaponComponent.Rotation * Vector3.up * weaponComponent.BulletConfig.speed
            });
        }

        public void OnGameStart()
        {            
            inputManager.OnFire += OnFire;
        }

        public void OnGameFinish()
        {
            inputManager.OnFire -= OnFire;
        }

        public void OnGamePause()
        {
            inputManager.OnFire -= OnFire;
        }

        public void OnGameResume()
        {            
            inputManager.OnFire += OnFire;
        }
    }
}   