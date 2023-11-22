using UnityEngine;

namespace ShootEmUp
{
    public sealed class CharacterAttackController : MonoBehaviour
    {
        [SerializeField] private BulletSystem bulletSystem;
        [SerializeField] private InputManager inputManager;

        [Space] 
        [SerializeField] private WeaponComponent weaponComponent;

        private void OnEnable()
        {
            inputManager.OnFire += OnFireFire;
        }

        private void OnDisable()
        {
            inputManager.OnFire -= OnFireFire;
        }

        private void OnFireFire()
        {
            Fire();
        }

        private void Fire()
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
    }
}   