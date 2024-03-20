using Entity.Components;
using Systems;
using UnityEngine;
using Zenject;

namespace Model
{
    public class ShootController : MonoBehaviour
    {
        [SerializeField] private Entity.Entity entity;
        private IComponent_Shoot _componentShoot;

        private InputSystem _inputSystem;

        private void Start()
        {
            entity.TryComponent(out _componentShoot);
        }

        private void OnEnable()
        {
            _inputSystem.OnShootRequest += ShootRequest;
        }

        private void OnDisable()
        {
            _inputSystem.OnShootRequest -= ShootRequest;
        }

        [Inject]
        public void Construct(InputSystem inputSystem)
        {
            _inputSystem = inputSystem;
        }

        private void ShootRequest()
        {
            _componentShoot.Shoot();
        }
    }
}