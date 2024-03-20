using Data.Event;
using UnityEngine;

namespace Entity.Components
{
    public class Component_MoveEvent : IComponent_Move
    {
        private readonly IAtomicAction<Vector3> _moved;

        public Component_MoveEvent(IAtomicAction<Vector3> moved)
        {
            _moved = moved;
        }

        public void Move(Vector3 moveDirection)
        {
            _moved?.Invoke(moveDirection);
        }
    }
}