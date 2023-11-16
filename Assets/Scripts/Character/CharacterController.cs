using UnityEngine;

namespace ShootEmUp
{
    public sealed class CharacterController : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        [SerializeField] private BulletSystem bulletSystem;
        [SerializeField] private InputManager inputManager;

        [Space] 
        [SerializeField] private MoveComponent moveComponent;
        [SerializeField] private HitPointsComponent hitPointsComponent;
        [SerializeField] private WeaponComponent weaponComponent;

        private void OnEnable()
        {
            hitPointsComponent.HpEmpty += OnCharacterDeath;
            inputManager.OnSpacePressed += OnSpacePressed_Fire;
        }

        private void OnDisable()
        {
            hitPointsComponent.HpEmpty -= OnCharacterDeath;
            inputManager.OnSpacePressed -= OnSpacePressed_Fire;
        }

        private void OnCharacterDeath(GameObject _)
        {
            gameManager.FinishGame();
        }

        private void OnSpacePressed_Fire()
        {
            Fire();
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Fire()
        {
            bulletSystem.FlyBulletByArgs(new BulletSystem.Args
            {
                isPlayer = true,
                physicsLayer = (int)weaponComponent.BulletConfig.physicsLayer,
                color = weaponComponent.BulletConfig.color,
                damage = weaponComponent.BulletConfig.damage,
                position = weaponComponent.Position,
                velocity = weaponComponent.Rotation * Vector3.up * weaponComponent.BulletConfig.speed
            });
        }

        private void Move()
        {
            moveComponent.MoveByRigidbodyVelocity(
                new Vector2(inputManager.HorizontalDirection, 0) * Time.fixedDeltaTime);
        }
    }
}