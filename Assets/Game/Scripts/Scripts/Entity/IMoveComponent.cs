using UnityEngine;

namespace Lessons.Lesson16_AtomicComponents.Entity
{
    public interface IMoveComponent
    {
        void Move(Vector3 moveDirection);
    }
}