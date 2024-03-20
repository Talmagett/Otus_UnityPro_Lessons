using Entity.Components;
using Systems;
using UnityEngine;
using Zenject;

namespace Model
{
    public class MoveController : MonoBehaviour
    {
        [SerializeField] private Entity.Entity entity;
        private IComponent_Move _componentMove;
        private InputSystem _inputSystem;

        private void Start()
        {
            entity.TryComponent(out _componentMove);
        }

        private void Update()
        {
            _componentMove.Move(_inputSystem.MoveDirection);
        }

        [Inject]
        public void Construct(InputSystem inputSystem)
        {
            _inputSystem = inputSystem;
        }
    }
}