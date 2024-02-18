using UnityEngine;

namespace Entity.Components
{
    public interface IComponent_Rotation
    {
        void Rotate(Vector3 rotateDirection);
    }
}