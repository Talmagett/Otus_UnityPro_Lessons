using Data.Event;
using Data.Variable;
using Logic;
using Logic.Mechanics;
using Scripts;
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
        
        [Header("Shoot")] 
        public AtomicEvent FireRequest;
        public AtomicEvent FireEvent;
        public Transform FirePoint;
        public Bullet BulletPrefab;
        
        //Logic:
        private TakeDamageMechanics _takeDamageMechanics;
        private DeathMechanics _deathMechanics;
        private MovementMechanicsV2 _movementMechanicsV2;
        private RotateMechanicsV2 _rotateMechanicsV2;
        private CanMoveMechanics _canMoveMechanics;
        private ShootMechanics _shootMechanics;

        private void Awake()
        {
            _takeDamageMechanics = new TakeDamageMechanics(HitPoints, TakeDamage, Death);
            _deathMechanics = new DeathMechanics(IsDead, Death);
            _movementMechanicsV2 = new MovementMechanicsV2(Speed, Moved, transform);
            _canMoveMechanics = new CanMoveMechanics(CanMove, IsDead);
            _rotateMechanicsV2 = new RotateMechanicsV2(Rotated, transform);
            _shootMechanics = new ShootMechanics(FireEvent, FirePoint, BulletPrefab, transform);
        }

        private void OnEnable()
        {
            _takeDamageMechanics.OnEnable();
            _deathMechanics.OnEnable();
            _shootMechanics.OnEnable();
            _movementMechanicsV2.OnEnable();
            _rotateMechanicsV2.OnEnable();
        }

        private void OnDisable()
        {
            _movementMechanicsV2.OnDisable();
            _rotateMechanicsV2.OnDisable();
            _takeDamageMechanics.OnDisable();
            _deathMechanics.OnDisable();
            _shootMechanics.OnDisable();
        }

        private void Update()
        {
            _canMoveMechanics.Update();
        }
    }
}