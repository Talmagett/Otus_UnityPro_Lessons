using UnityEngine;

namespace Lessons.Lesson14_ModuleMechanics
{
    public class RotateMechanics
    {
        private readonly IAtomicValue<Vector3> _moveDirection;
        private readonly Transform _target;
        private readonly IAtomicValue<bool> _canMove;

        public RotateMechanics(IAtomicValue<Vector3> moveDirection, Transform target, IAtomicValue<bool> canMove)
        {
            _moveDirection = moveDirection;
            _target = target;
            _canMove = canMove;
        }

        public void Update()
        {
            if (!_canMove.Value)
            {
                return;
            }

            if (_moveDirection.Value == Vector3.zero)
            {
                return;
            }
            
            var rotation = Quaternion.LookRotation(_moveDirection.Value);
            _target.rotation = Quaternion.Lerp(_target.rotation, rotation, Time.deltaTime * 50f);
        }
    }
}