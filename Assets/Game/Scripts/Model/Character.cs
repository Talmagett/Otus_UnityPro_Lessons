using Data.Event;
using Data.Variable;
using Logic;
using Logic.Data;
using Logic.Mechanics;
using Logic.Mechanics.LifeMechanics;
using Logic.Mechanics.ShootMechanics;
using Logic.Mechanics.TimeMechanics;
using Logic.Mechanics.TransformMechanics;
using UnityEngine;

namespace Model
{
    public class Character : MonoBehaviour
    {
        //Data:
        public LifeData Life;
        public MovementData Movement;
        public AtomicEvent<Vector3> RotatedEvent;
        
        public ResourceData BulletsData;
        public TimerData AmmoRefillTimer;
        public TimerData AttackCooldownTimer;
        
        public AttackData Attack;
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
            _takeDamageMechanics = new TakeDamageMechanics(Life);
            _deathMechanics = new DeathMechanics(Life);
            
            _movementMechanicsEvent = new MovementMechanicsEvent(Movement, transform);
            _canMoveMechanics = new CanMoveMechanics(Movement.CanMove, Life.IsDead);
            _rotateMechanicsEvent = new RotateMechanicsEvent(RotatedEvent, transform);

            _refillTimerMechanics = new TimerMechanics(AmmoRefillTimer);
            _ammoRefillMechanics = new AmmoRefillMechanics(BulletsData, AmmoRefillTimer);
            _canShootMechanics = new CanShootMechanics(Attack.CanAttack,BulletsData.Count,AttackCooldownTimer.Finished);
            _ammoMechanics = new AmmoMechanics(Attack, BulletsData.Count, AttackCooldownTimer.Finished);
            _attackCooldownTimerMechanics = new TimerMechanics(AttackCooldownTimer);
            _shootMechanics = new ShootMechanics(Attack.AttackEvent, FirePoint, BulletPrefab, transform);
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