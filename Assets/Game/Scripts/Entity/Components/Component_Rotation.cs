using Data.Event;
using UnityEngine;

namespace Entity.Components
{
    public class Component_Rotation : IComponent_Rotation
    {
        private readonly IAtomicAction<Vector3> _rotated;

        public Component_Rotation(IAtomicAction<Vector3> rotated)
        {
            _rotated = rotated;
        }

        public void Rotate(Vector3 rotateDirection)
        {
            _rotated?.Invoke(rotateDirection);
        }
    }
}