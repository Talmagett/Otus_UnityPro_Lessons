using Entity.Components;
using UnityEngine;

namespace Visual
{
    public class AnimatorDispatcher : MonoBehaviour
    {
        [SerializeField] private Entity.Entity entity;

        public void ReceiveEvent(string value)
        {
            if (value is "shoot" or "attack")
            {
                if (entity.TryComponent(out IComponent_AttackEvent attackEvent))
                    attackEvent.Attack();
            }
        }
    }
}