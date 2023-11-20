using GameManager;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class CharacterController : MonoBehaviour, Listeners.IOnGameStarted, Listeners.IOnGameFinished,
        Listeners.IOnGamePaused, Listeners.IOnGameResumed
    {
        [SerializeField] private GameManager.GameManager gameManager;
        [SerializeField] private BulletSystem bulletSystem;
        [SerializeField] private InputManager inputManager;

        [Space] 
        [SerializeField] private MoveComponent moveComponent;
        [SerializeField] private HitPointsComponent hitPointsComponent;
        [SerializeField] private WeaponComponent weaponComponent;

        private bool _canControl;
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
            if (!_canControl)
                return;
            
            Fire();
        }

        private void FixedUpdate()
        {
            if (!_canControl)
                return;
            
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

        public void OnGameStarted()
        {
            _canControl = true;
        }

        public void OnGameFinished()
        {
            _canControl = false;
        }

        public void OnGamePaused()
        {
            _canControl = false;
        }

        public void OnGameResumed()
        {
            _canControl = true;
        }
    }
}