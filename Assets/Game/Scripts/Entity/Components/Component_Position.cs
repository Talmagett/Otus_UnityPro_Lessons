using UnityEngine;

namespace Entity.Components
{
    public class Component_Position : IComponent_Position
    {
        private readonly Transform _transform;

        public Component_Position(Transform transform)
        {
            _transform = transform;
        }

        public Vector3 GetPosition()
        {
            return _transform.position;
        }
    }
}