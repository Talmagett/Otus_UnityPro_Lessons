using Data.Event;
using UnityEngine;

namespace Logic.Mechanics.TransformMechanics
{
    public class RotateMechanicsV2
    {
        private readonly AtomicEvent<Vector3> _moved;
        private readonly Transform _transform;

        public RotateMechanicsV2(AtomicEvent<Vector3> moved, Transform transform)
        {
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
            _transform.rotation = Quaternion.LookRotation(moveDirection);
        }
    }
}