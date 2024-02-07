using System;
using EcsEngine.Components.Life;
using EcsEngine.Systems;
using EcsEngine.Systems.Attack;
using EcsEngine.Systems.Life;
using EcsEngine.Systems.Movement;
using EcsEngine.Systems.ViewSystems;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.Entities;
using Leopotam.EcsLite.ExtendedSystems;
using Leopotam.EcsLite.Helpers;
using Leopotam.EcsLite.UnityEditor;
using UnityEngine;

namespace EcsEngine
{
    public sealed class EcsAdmin : MonoBehaviour
    {
        private EntityManager _entityManager;
        private EcsWorld _events;
        private IEcsSystems _systems;

        private EcsWorld _world;
        public static EcsAdmin Instance { get; private set; }

        private void Awake()
        {
            Instance = this;

            _entityManager = new EntityManager();

            _world = new EcsWorld();
            _events = new EcsWorld();
            _systems = new EcsSystems(_world);

            _systems.AddWorld(_events, EcsWorlds.Events);

            _systems

                //Game Logic:
                .Add(new CooldownSystem())
                .Add(new TargetSelectorSystem())
                .Add(new EnemyInRangeCheckSystem())
                .Add(new MoveToTargetSystem())
                .Add(new MovementSystem())
                
                .Add(new AttackRequestSystem())
                .Add(new ArcherAttackRequestSystem())
                .Add(new UnitSpawnRequestSystem())
                .Add(new SpawnRequestSystem())
                
                .Add(new ArrowCollisionRequestSystem())
                .Add(new ArrowDestroySystem())
                
                .Add(new HealthEmptySystem())
                .Add(new DeathRequestSystem())
                .Add(new TakeDamageRequestSystem())
                .Add(new GamePlaySystem())

                //Game Listeners:

                //View:
                .Add(new TransformViewSynchronizer())
                .Add(new AnimatorDeathListener())
                .Add(new AnimatorTakeDamageListener())
                .Add(new AnimatorMoveListener())
                //Editor:
#if UNITY_EDITOR
                .Add(new EcsWorldDebugSystem())
                .Add(new EcsWorldDebugSystem(EcsWorlds.Events))
#endif
                //Clean Up:
                .Add(new OneFrameEventSystem())
                .DelHere<DeathEvent>();
        }

        private void Start()
        {
            _entityManager.Initialize(_world);
            _systems.Inject(_entityManager);
            _systems.Init();
        }

        private void Update()
        {
            _systems?.Run();
        }

        private void OnDestroy()
        {
            if (_systems != null)
            {
                // list of custom worlds will be cleared
                // during IEcsSystems.Destroy(). so, you
                // need to save it here if you need.
                _systems.Destroy();
                _systems = null;
            }

            // cleanup custom worlds here.

            // cleanup default world.
            if (_world != null)
            {
                _world.Destroy();
                _world = null;
            }
        }

        public EcsEntityBuilder CreateEntity(string worldName = null)
        {
            return new EcsEntityBuilder(_systems.GetWorld(worldName));
        }

        public EcsWorld GetWorld(string worldName = null)
        {
            return worldName switch
            {
                null => _world,
                EcsWorlds.Events => _events,
                _ => throw new Exception($"World with name {worldName} is not found!")
            };
        }
    }
}