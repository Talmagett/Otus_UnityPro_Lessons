using Data.Variable;
using Entity;
using Logic.Data;
using Logic.Mechanics;
using Logic.Mechanics.LifeMechanics;
using Logic.Mechanics.TimeMechanics;
using Logic.Mechanics.TransformMechanics;
using UnityEngine;
using Zenject;

namespace Model
{
    public class Zombie : MonoBehaviour
    {
        //Data:
        public LifeData Life;
        public AtomicVariable<GameObject> GameObjectToHide;
        public AtomicVariable<Collider> ColliderToDisable;
        public MovementData Movement;
        public AtomicVariable<float> rotationSpeed;

        public TimerData AttackCooldownTimer;
        public AttackData Attack;

        private TimerMechanics _attackTimerMechanics;

        //Logic:
        private CanMoveMechanics _canMoveMechanics;
        private CharacterEntity _characterEntity;
        private DeathMechanics _deathMechanics;
        private DestroyMechanics _destroyMechanics;
        private DisableColliderMechanics _disableColliderMechanics;
        private HideGameObjectMechanics _hideGameObjectMechanics;
        private MeleeAttackMechanics _meleeAttackMechanics;
        private MoveToTargetMechanics _moveToTargetMechanics;
        private RotateToMechanics _rotateMechanics;
        private TakeDamageMechanics _takeDamageMechanics;

        private void Awake()
        {
            _takeDamageMechanics = new TakeDamageMechanics(Life);
            _deathMechanics = new DeathMechanics(Life);
            _hideGameObjectMechanics = new HideGameObjectMechanics(Life.DeathEvent, GameObjectToHide.Value);
            _disableColliderMechanics = new DisableColliderMechanics(Life.DeathEvent, ColliderToDisable.Value);
            //_destroyMechanics = new DestroyMechanics(Death, gameObject);
            _moveToTargetMechanics = new MoveToTargetMechanics(Movement, transform, _characterEntity.transform);
            _rotateMechanics =
                new RotateToMechanics(transform, _characterEntity.transform, Movement.CanMove, rotationSpeed);
            _canMoveMechanics = new CanMoveMechanics(Movement.CanMove, Life.IsDead);
            _meleeAttackMechanics = new MeleeAttackMechanics(Attack, GetComponent<Entity.Entity>());
            _attackTimerMechanics = new TimerMechanics(AttackCooldownTimer);
        }

        private void Update()
        {
            _canMoveMechanics.Update();
            _moveToTargetMechanics.Update();
            _rotateMechanics.Update();
            _attackTimerMechanics.Update();
        }

        private void OnEnable()
        {
            _takeDamageMechanics.OnEnable();
            _deathMechanics.OnEnable();
            _hideGameObjectMechanics.OnEnable();
            _attackTimerMechanics.OnEnable();
            _disableColliderMechanics.OnEnable();
        }

        private void OnDisable()
        {
            _takeDamageMechanics.OnDisable();
            _deathMechanics.OnDisable();
            _hideGameObjectMechanics.OnDisable();
            _attackTimerMechanics.OnDisable();
            _disableColliderMechanics.OnDisable();
        }

        private void OnCollisionEnter(Collision other)
        {
            _meleeAttackMechanics.OnTriggerEnter(other.collider);
        }

        [Inject]
        public void Construct(CharacterEntity characterEntity)
        {
            _characterEntity = characterEntity;
        }
    }
}