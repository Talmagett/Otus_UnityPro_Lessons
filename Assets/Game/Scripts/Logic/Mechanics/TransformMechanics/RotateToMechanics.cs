using Data.Variable;
using UnityEngine;

namespace Logic.Mechanics.TransformMechanics
{
    public class RotateToMechanics
    {
        private readonly IAtomicValue<bool> _canMove;
        private readonly Transform _rotatingTransform;
        private readonly Transform _target;
        private float _rotationSpeed=100f;
        
        public RotateToMechanics(Transform rotatingTransform, Transform target, IAtomicValue<bool> canMove)
        {
            _rotatingTransform = rotatingTransform;
            _target = target;
            _canMove = canMove;
        }

        public void Update()
        {
            if (!_canMove.Value) return;
            //var targetRotation = Quaternion.LookRotation(_target.position, Vector3.up);
            //_rotatingTransform.rotation = Quaternion.Lerp(_rotatingTransform.rotation, targetRotation, _rotationSpeed*Time.deltaTime);
        }
    }
}