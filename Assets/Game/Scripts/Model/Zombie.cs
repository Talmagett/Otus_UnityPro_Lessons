using System;
using Data.Event;
using Data.Variable;
using Entity;
using Logic;
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
        private CharacterEntity _characterEntity;

        //Logic:
        private CanMoveMechanics _canMoveMechanics;
        private DeathMechanics _deathMechanics;
        private HideGameObjectMechanics _hideGameObjectMechanics;
        private DisableColliderMechanics _disableColliderMechanics;
        private DestroyMechanics _destroyMechanics;
        private MoveToTargetMechanics _moveToTargetMechanics;
        private RotateToMechanics _rotateMechanics;

        private TimerMechanics _attackTimerMechanics;
        private MeleeAttackMechanics _meleeAttackMechanics;
        private TakeDamageMechanics _takeDamageMechanics;
        
        [Inject]
        public void Construct(CharacterEntity characterEntity)
        {
            _characterEntity = characterEntity;
        }
        
        private void Awake()
        {
            _takeDamageMechanics = new TakeDamageMechanics(Life);
            _deathMechanics = new DeathMechanics(Life);
            _hideGameObjectMechanics = new HideGameObjectMechanics(Life.DeathEvent, GameObjectToHide.Value);
            _disableColliderMechanics = new DisableColliderMechanics(Life.DeathEvent,ColliderToDisable.Value);
            //_destroyMechanics = new DestroyMechanics(Death, gameObject);
            _moveToTargetMechanics = new MoveToTargetMechanics(Movement,transform, _characterEntity.transform);
            _rotateMechanics = new RotateToMechanics(transform, _characterEntity.transform, Movement.CanMove,rotationSpeed);
            _canMoveMechanics = new CanMoveMechanics(Movement.CanMove, Life.IsDead);
            _meleeAttackMechanics = new MeleeAttackMechanics(Attack,GetComponent<Entity.Entity>());
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
    }
}