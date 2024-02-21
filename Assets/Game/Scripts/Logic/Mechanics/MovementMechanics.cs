using Data.Variable;
using UnityEngine;

namespace Logic.Mechanics
{
    public class MovementMechanics
    {
        private readonly IAtomicValue<float> _speed;
        private readonly IAtomicValue<Vector3> _moveDirection;
        private readonly Transform _target;
        private readonly IAtomicValue<bool> _canMove;

        public MovementMechanics(IAtomicValue<float> speed, IAtomicValue<Vector3> moveDirection, Transform target, IAtomicValue<bool> canMove)
        {
            _speed = speed;
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
            
            _target.position += _moveDirection.Value * _speed.Value * Time.deltaTime;
        }
    }
}