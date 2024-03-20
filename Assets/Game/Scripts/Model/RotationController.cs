using Entity.Components;
using Systems;
using UnityEngine;
using Zenject;

namespace Model
{
    public class RotationController : MonoBehaviour
    {
        [SerializeField] private Entity.Entity entity;
        private IComponent_Position _componentPosition;
        private IComponent_Rotation _componentRotation;

        private InputSystem _inputSystem;

        private void Start()
        {
            entity.TryComponent(out _componentRotation);
            entity.TryComponent(out _componentPosition);
        }

        private void Update()
        {
            var direction = (_inputSystem.MousePositionOnY - _componentPosition.GetPosition()).normalized;
            _componentRotation.Rotate(direction);
        }

        [Inject]
        public void Construct(InputSystem inputSystem)
        {
            _inputSystem = inputSystem;
        }
    }
}