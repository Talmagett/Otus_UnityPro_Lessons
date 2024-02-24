using Data.Variable;
using UnityEngine;

namespace Logic.Mechanics.TransformMechanics
{
    public class MoveToTargetMechanics
    {
        private readonly IAtomicValue<bool> _canMove;
        private readonly Transform _movingTransform;
        private readonly IAtomicValue<float> _speed;
        private readonly Transform _target;

        public MoveToTargetMechanics(IAtomicValue<float> speed, Transform movingTransform, Transform target,
            IAtomicValue<bool> canMove)
        {
            _speed = speed;
            _movingTransform = movingTransform;
            _target = target;
            _canMove = canMove;
        }

        public void Update()
        {
            if (!_canMove.Value) return;

            _movingTransform.position = Vector3.MoveTowards(_movingTransform.position, _target.position,
                _speed.Value * Time.deltaTime);
        }
    }
}