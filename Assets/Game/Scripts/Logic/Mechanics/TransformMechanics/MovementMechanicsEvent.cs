using Logic.Data;
using UnityEngine;

namespace Logic.Mechanics.TransformMechanics
{
    public class MovementMechanicsEvent
    {
        private readonly MovementData _movementDataData;
        private readonly Transform _transform;

        public MovementMechanicsEvent(MovementData movementData, Transform transform)
        {
            _movementDataData = movementData;
            _transform = transform;
        }

        public void OnEnable()
        {
            _movementDataData.MovedEvent.Subscribe(OnMoved);
        }

        public void OnDisable()
        {
            _movementDataData.MovedEvent.Unsubscribe(OnMoved);
        }

        private void OnMoved(Vector3 moveDirection)
        {
            _movementDataData.MoveDirection.Value = moveDirection;
            _transform.position += moveDirection * (_movementDataData.Speed.Value * Time.deltaTime);
        }
    }
}