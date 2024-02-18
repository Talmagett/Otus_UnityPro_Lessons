using Lessons.Lesson14_ModuleMechanics;
using UnityEngine;

namespace Lessons.Lesson16_AtomicComponents.Entity
{
    public class MoveComponent : IMoveComponent
    {
        private readonly IAtomicAction<Vector3> _moved;

        public MoveComponent(IAtomicAction<Vector3> moved)
        {
            _moved = moved;
        }

        public void Move(Vector3 moveDirection)
        {
            _moved?.Invoke(moveDirection);
        }
    }
}