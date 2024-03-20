using Data.Event;
using Data.Variable;
using Logic;
using Logic.Data;
using Logic.Mechanics;
using Logic.Mechanics.LifeMechanics;
using Logic.Mechanics.ShootMechanics;
using Logic.Mechanics.TransformMechanics;
using UnityEngine;

namespace Model
{
    public class Bullet : MonoBehaviour
    {
        //Data:
        public MovementData Movement;
        
        public AtomicVariable<int> Damage;
        public AtomicVariable<float> LifeTime;
        public AtomicEvent Death;
        
        //Logic:
        private BulletCollisionMechanics _bulletCollisionMechanics;
        private DestroyMechanics _destroyMechanics;
        private LifeTimeMechanics _lifeTimeMechanics;
        private MovementMechanicsUpdate _movementMechanicsUpdate;

        private void Awake()
        {
            _movementMechanicsUpdate = new MovementMechanicsUpdate(Movement, transform);
            _bulletCollisionMechanics = new BulletCollisionMechanics(Damage, Death);
            _lifeTimeMechanics = new LifeTimeMechanics(LifeTime, Death);
            _destroyMechanics = new DestroyMechanics(Death, gameObject);
        }

        private void Update()
        {
            _movementMechanicsUpdate.Update();
            _lifeTimeMechanics.Update();
        }

        private void OnEnable()
        {
            _destroyMechanics.OnEnable();
        }

        private void OnDisable()
        {
            _destroyMechanics.OnDisable();
        }

        private void OnTriggerEnter(Collider other)
        {
            _bulletCollisionMechanics.OnTriggerEnter(other);
        }
    }
}