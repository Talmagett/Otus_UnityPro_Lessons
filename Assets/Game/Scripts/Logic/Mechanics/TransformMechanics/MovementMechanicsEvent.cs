using Data.Event;
using Data.Variable;
using UnityEngine;

namespace Logic.Mechanics.TransformMechanics
{
    public class MovementMechanicsEvent
    {
        private readonly AtomicEvent<Vector3> _moved;
        private readonly AtomicVariable<float> _speed;
        private readonly Transform _transform;

        public MovementMechanicsEvent(AtomicVariable<float> speed, AtomicEvent<Vector3> moved, Transform transform)
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