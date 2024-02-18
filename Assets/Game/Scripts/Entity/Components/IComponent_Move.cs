using UnityEngine;

namespace Entity.Components
{
    public interface IComponent_Move
    {
        void Move(Vector3 moveDirection);
    }
}