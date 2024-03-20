using Logic.Data;
using UnityEngine;

namespace Logic.Mechanics.TransformMechanics
{
    public class MovementMechanicsUpdate
    {
        private readonly MovementData _movementDataData;
        private readonly Transform _transform;

        public MovementMechanicsUpdate(MovementData movementData, Transform transform)
        {
            _movementDataData = movementData;
            _transform = transform;
        }

        public void Update()
        {
            if (!_movementDataData.CanMove.Value) return;

            _transform.position +=
                _movementDataData.MoveDirection.Value * (_movementDataData.Speed.Value * Time.deltaTime);
        }
    }
}