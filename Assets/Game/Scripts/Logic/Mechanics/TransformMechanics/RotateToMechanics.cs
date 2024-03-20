using Data.Variable;
using UnityEngine;

namespace Logic.Mechanics.TransformMechanics
{
    public class RotateToMechanics
    {
        private readonly IAtomicValue<bool> _canMove;
        private readonly IAtomicValue<float> _rotationSpeed;
        private readonly Transform _target;
        private readonly Transform _transform;

        public RotateToMechanics(Transform transform, Transform target, IAtomicValue<bool> canMove,
            IAtomicValue<float> rotationSpeed)
        {
            _transform = transform;
            _target = target;
            _canMove = canMove;
            _rotationSpeed = rotationSpeed;
        }

        public void Update()
        {
            if (!_canMove.Value) return;
            _transform.LookAt(_target, Vector3.up);
        }
    }
}