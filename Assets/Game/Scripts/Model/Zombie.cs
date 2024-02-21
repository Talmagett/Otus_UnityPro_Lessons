using Data.Event;
using Data.Variable;
using Entity;
using Logic;
using Logic.Mechanics;
using UnityEngine;
using Zenject;

namespace Model
{
    public class Zombie : MonoBehaviour
    {
        //Data:
        public AtomicVariable<int> HitPoints;
        public AtomicEvent<int> TakeDamage;

        public AtomicVariable<bool> IsDead;
        public AtomicEvent Death;

        public AtomicVariable<float> Speed;

        public AtomicVariable<bool> CanMove;

        private CanMoveMechanics _canMoveMechanics;
        private DeathMechanics _deathMechanics;
        private DestroyMechanics _destroyMechanics;
        private MoveToTargetMechanics _moveToTargetMechanics;
        private RotateToMechanics _rotateMechanics;

        [Header("Shoot")]
        public AtomicEvent AttackEvent;
        
        //Logic:
        private TakeDamageMechanics _takeDamageMechanics;

        private CharacterEntity _characterEntity;
        [Inject]
        public void Construct(CharacterEntity characterEntity)
        {
            _characterEntity = characterEntity;
        }
        
        private void Awake()
        {
            _takeDamageMechanics = new TakeDamageMechanics(HitPoints, TakeDamage, Death);
            _deathMechanics = new DeathMechanics(IsDead, Death);
            _destroyMechanics = new DestroyMechanics(Death, gameObject);
            _moveToTargetMechanics = new MoveToTargetMechanics(Speed,transform,_characterEntity.transform, CanMove);
            _rotateMechanics = new RotateToMechanics(transform,_characterEntity.transform,CanMove);
            _canMoveMechanics = new CanMoveMechanics(CanMove, IsDead);
        }

        private void Update()
        {
            _canMoveMechanics.Update();
            _moveToTargetMechanics.Update();
            _rotateMechanics.Update();
        }

        private void OnEnable()
        {
            _takeDamageMechanics.OnEnable();
            _deathMechanics.OnEnable();
            _destroyMechanics.OnEnable();
        }

        private void OnDisable()
        {
            _takeDamageMechanics.OnDisable();
            _deathMechanics.OnDisable();
            _destroyMechanics.OnDisable();
        }
    }
}