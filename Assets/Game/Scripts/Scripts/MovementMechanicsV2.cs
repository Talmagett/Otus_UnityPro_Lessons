using Data.Event;
using Data.Variable;
using UnityEngine;

namespace Scripts
{
    public class MovementMechanicsV2
    {
        private readonly AtomicVariable<float> _speed;
        private readonly AtomicEvent<Vector3> _moved;
        private readonly Transform _transform;

        public MovementMechanicsV2(AtomicVariable<float> speed, AtomicEvent<Vector3> moved, Transform transform)
        {
            _speed = speed;
            _moved = moved;
            _transform = transform;
        }

        public void OnEnable()
        {
            _moved.Subscribe(OnMoved);
        }

        public void OnDisable()
        {
            _moved.Unsubscribe(OnMoved);
        }

        private void OnMoved(Vector3 moveDirection)
        {
            _transform.position += moveDirection * _speed.Value * Time.deltaTime;
        }
    }
}