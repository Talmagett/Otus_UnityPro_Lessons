using Data.Event;
using UnityEngine;

namespace Entity.Components
{
    public class Component_Move : IComponent_Move
    {
        private readonly IAtomicAction<Vector3> _moved;

        public Component_Move(IAtomicAction<Vector3> moved)
        {
            _moved = moved;
        }

        public void Move(Vector3 moveDirection)
        {
            _moved?.Invoke(moveDirection);
        }
    }
}