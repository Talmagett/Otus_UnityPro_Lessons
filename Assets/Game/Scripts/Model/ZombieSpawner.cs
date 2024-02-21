using System;
using Data.Variable;
using Logic.Mechanics;
using UnityEngine;
using Zenject;

namespace Model
{
    public class ZombieSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject zombiePrefab;
        [SerializeField] private Transform zombieParent;
        
        public AtomicVariable<float> SpawnCooldown;
        public AtomicVariable<float> SpawnTimer;
        public AtomicVariable<bool> CanSpawn;
        
        private TimerMechanics _timerMechanics;
        private SpawnMechanics _spawnMechanics;

        private DiContainer _diContainer;
        
        [Inject]
        public void Construct(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }
        private void Awake()
        {
            _timerMechanics = new TimerMechanics(SpawnTimer,SpawnCooldown,CanSpawn);
            _spawnMechanics = new SpawnMechanics(zombiePrefab,zombieParent,CanSpawn,_diContainer);
        }

        private void OnEnable()
        {
            _timerMechanics.OnEnable();
        }

        private void OnDisable()
        {
            _timerMechanics.OnDisable();
        }

        private void Update()
        {
            _timerMechanics.Update();
            _spawnMechanics.Update();
        }
    }
}