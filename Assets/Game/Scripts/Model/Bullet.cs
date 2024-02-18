using Data.Event;
using Data.Variable;
using Logic;
using UnityEngine;

namespace Model
{
    public class Bullet : MonoBehaviour
    {
        //Data:
        public AtomicVariable<float> Speed;
        public AtomicVariable<Vector3> MoveDirection;

        public AtomicVariable<bool> CanMove;

        public AtomicVariable<int> Damage;
        public AtomicVariable<float> LifeTime;
        public AtomicEvent Death;

        //Logic:
        private MovementMechanics _movementMechanics;
        private BulletCollisionMechanics _bulletCollisionMechanics;
        private LifeTimeMechanics _lifeTimeMechanics;
        private DestroyMechanics _destroyMechanics;
        
        private void Awake()
        {
            _movementMechanics = new MovementMechanics(Speed, MoveDirection, transform, CanMove);
            _bulletCollisionMechanics = new BulletCollisionMechanics(Damage, Death);
            _lifeTimeMechanics = new LifeTimeMechanics(LifeTime, Death);
            _destroyMechanics = new DestroyMechanics(Death, gameObject);
        }

        private void OnEnable()
        {
            _destroyMechanics.OnEnable();
        }

        private void OnDisable()
        {
            _destroyMechanics.OnDisable();
        }

        private void Update()
        {
            _movementMechanics.Update();
            _lifeTimeMechanics.Update();
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("on trigger enter");
            _bulletCollisionMechanics.OnTriggerEnter(other);
        }
    }
}