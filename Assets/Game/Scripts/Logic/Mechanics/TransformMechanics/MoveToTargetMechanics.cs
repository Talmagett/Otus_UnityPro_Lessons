using Logic.Data;
using UnityEngine;

namespace Logic.Mechanics.TransformMechanics
{
    public class MoveToTargetMechanics
    {
        private readonly MovementData _movementData; 
        private readonly Transform _movingTransform;
        private readonly Transform _target;

        public MoveToTargetMechanics(MovementData movementData, Transform movingTransform, Transform target)
        {
            _movementData = movementData;
            _movingTransform = movingTransform;
            _target = target;
        }

        public void Update()
        {
            if (!_movementData.CanMove.Value) return;

            _movingTransform.position = Vector3.MoveTowards(_movingTransform.position, _target.position,
                _movementData.Speed.Value * Time.deltaTime);
        }
    }
}