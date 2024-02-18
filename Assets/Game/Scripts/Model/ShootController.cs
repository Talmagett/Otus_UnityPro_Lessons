using System;
using Data.Event;
using Entity.Components;
using Systems;
using UnityEngine;
using Zenject;

namespace Model
{
    public class ShootController : MonoBehaviour
    {
        [SerializeField] private Entity.Entity entity;

        private InputSystem _inputSystem;
        private IComponent_Shoot _componentShoot;

        private void Start()
        {
            entity.TryComponent(out _componentShoot);
        }

        [Inject]
        public void Construct(InputSystem inputSystem)
        {
            _inputSystem = inputSystem;
        }

        private void OnEnable()
        {
            _inputSystem.OnShootEvent += ShootRequest;
        }

        private void OnDisable()
        {
            _inputSystem.OnShootEvent -= ShootRequest;
        }

        private void ShootRequest()
        {
            _componentShoot.Shoot();
        }
    }
}