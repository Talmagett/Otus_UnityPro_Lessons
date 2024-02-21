using Data.Variable;
using UnityEngine;

namespace Logic.Mechanics
{
    public class RotateToMechanics
    {
        private readonly Transform _rotatingTransform;
        private readonly Transform _target;
        private readonly IAtomicValue<bool> _canMove;

        public RotateToMechanics(Transform rotatingTransform, Transform target, IAtomicValue<bool> canMove)
        {
            _rotatingTransform = rotatingTransform;
            _target = target;
            _canMove = canMove;
        }

        public void Update()
        {
            if (!_canMove.Value)
            {
                return;
            }

            _rotatingTransform.rotation = Quaternion.LookRotation(_target.position, Vector3.up);
        }
    }
}