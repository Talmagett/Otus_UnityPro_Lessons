using Data.Event;
using Data.Variable;
using Logic;
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

        public ResourceData BulletsData;
        public TimerData AmmoRefillTimer;
        public TimerData AttackCooldownTimer;
        public AtomicVariable<bool> CanShoot;
        
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
        private TimerMechanics _attackCooldownTimerMechanics;
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

            _refillTimerMechanics = new TimerMechanics(AmmoRefillTimer);
            _ammoRefillMechanics = new AmmoRefillMechanics(BulletsData, AmmoRefillTimer);
            _canShootMechanics = new CanShootMechanics(CanShoot,BulletsData.Count,AttackCooldownTimer.Finished);
            _ammoMechanics = new AmmoMechanics(FireRequest, BulletsData.Count, CanShoot, FireEvent);
            _attackCooldownTimerMechanics = new TimerMechanics(AttackCooldownTimer);
            _shootMechanics = new ShootMechanics(FireEvent, FirePoint, BulletPrefab, transform);
        }

        private void Update()
        {
            _canMoveMechanics.Update();
            _refillTimerMechanics.Update();
            _attackCooldownTimerMechanics.Update();
        }

        private void OnEnable()
        {
            _takeDamageMechanics.OnEnable();
            _deathMechanics.OnEnable();
            _ammoRefillMechanics.OnEnable();
            _shootMechanics.OnEnable();
            _movementMechanicsEvent.OnEnable();
            _rotateMechanicsEvent.OnEnable();
            _ammoMechanics.OnEnable();
            _refillTimerMechanics.OnEnable();
            _canShootMechanics.OnEnable();
            _attackCooldownTimerMechanics.OnEnable();
        }

        private void OnDisable()
        {
            _movementMechanicsEvent.OnDisable();
            _rotateMechanicsEvent.OnDisable();
            _ammoRefillMechanics.OnDisable();
            _takeDamageMechanics.OnDisable();
            _deathMechanics.OnDisable();
            _shootMechanics.OnDisable();
            _ammoMechanics.OnDisable();
            _refillTimerMechanics.OnDisable();
            _canShootMechanics.OnDisable();
            _attackCooldownTimerMechanics.OnDisable();
        }
    }
}