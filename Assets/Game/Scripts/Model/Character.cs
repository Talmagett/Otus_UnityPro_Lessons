using Data.Event;
using Data.Variable;
using Logic.Mechanics;
using Logic.Mechanics.ShootMechanics;
using Logic.Mechanics.TransformMechanics;
using UnityEngine;

namespace Model
{
    public class Character : MonoBehaviour
    {
        //Data:
        public AtomicVariable<int> HitPoints;
        public AtomicEvent<int> TakeDamage;

        public AtomicVariable<bool> IsDead;
        public AtomicEvent Death;

        public AtomicEvent<Vector3> Moved;
        public AtomicVariable<float> Speed;
        public AtomicVariable<bool> CanMove;
        public AtomicEvent<Vector3> Rotated;

        [Header("Shoot")] public AtomicEvent FireRequest;

        public AtomicVariable<int> BulletsCount;
        public AtomicVariable<int> BulletsMaxCount;
        public AtomicVariable<bool> CanShoot;

        public AtomicVariable<float> RefillTimer;
        public AtomicVariable<float> RefillMaxTime;
        public AtomicVariable<bool> OnRefilled;

        public AtomicEvent FireEvent;
        public Transform FirePoint;
        public Bullet BulletPrefab;
        
        //Logic:
        private AmmoMechanics _ammoMechanics;
        private AmmoRefillMechanics _ammoRefillMechanics;
        private CanMoveMechanics _canMoveMechanics;
        private CanShootMechanics _canShootMechanics;
        private DeathMechanics _deathMechanics;
        private MovementMechanicsEvent _movementMechanicsEvent;

        private TimerMechanics _refillTimerMechanics;
        private RotateMechanicsEvent _rotateMechanicsEvent;
        private ShootMechanics _shootMechanics;
        private TakeDamageMechanics _takeDamageMechanics;

        private void Awake()
        {
            _takeDamageMechanics = new TakeDamageMechanics(HitPoints, TakeDamage, Death);
            _deathMechanics = new DeathMechanics(IsDead, Death);
            _movementMechanicsEvent = new MovementMechanicsEvent(Speed, Moved, transform);
            _canMoveMechanics = new CanMoveMechanics(CanMove, IsDead);
            _rotateMechanicsEvent = new RotateMechanicsEvent(Rotated, transform);

            _refillTimerMechanics = new TimerMechanics(RefillTimer, RefillMaxTime, OnRefilled);
            _ammoRefillMechanics = new AmmoRefillMechanics(BulletsCount, BulletsMaxCount, OnRefilled);
            _canShootMechanics = new CanShootMechanics(BulletsCount, CanShoot);
            _ammoMechanics = new AmmoMechanics(FireRequest, BulletsCount, CanShoot, FireEvent);
            _shootMechanics = new ShootMechanics(FireEvent, FirePoint, BulletPrefab, transform);
        }

        private void Update()
        {
            _canMoveMechanics.Update();
            _refillTimerMechanics.Update();
            _ammoRefillMechanics.Update();
            _canShootMechanics.Update();
        }

        private void OnEnable()
        {
            _takeDamageMechanics.OnEnable();
            _deathMechanics.OnEnable();
            _shootMechanics.OnEnable();
            _movementMechanicsEvent.OnEnable();
            _rotateMechanicsEvent.OnEnable();
            _ammoMechanics.OnEnable();
            _refillTimerMechanics.OnEnable();
        }

        private void OnDisable()
        {
            _movementMechanicsEvent.OnDisable();
            _rotateMechanicsEvent.OnDisable();
            _takeDamageMechanics.OnDisable();
            _deathMechanics.OnDisable();
            _shootMechanics.OnDisable();
            _ammoMechanics.OnDisable();
            _refillTimerMechanics.OnDisable();
        }
    }
}