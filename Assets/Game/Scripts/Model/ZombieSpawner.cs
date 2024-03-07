using Data.Variable;
using Logic.Mechanics;
using UnityEngine;
using Zenject;

namespace Model
{
    public class ZombieSpawner : MonoBehaviour
    {
        //Data
        public AtomicVariable<GameObject> zombiePrefab;
        public AtomicVariable<Transform> zombieParent;
        public AtomicVariable<float> SpawnCooldown;
        public AtomicVariable<float> SpawnTimer;
        public AtomicVariable<bool> CanSpawn;

        //Logic
        private SpawnMechanics _spawnMechanics;
        private TimerMechanics _timerMechanics;

        private DiContainer _diContainer;

        private void Awake()
        {
            _timerMechanics = new TimerMechanics(SpawnTimer, SpawnCooldown, CanSpawn);
            _spawnMechanics = new SpawnMechanics(zombiePrefab.Value, zombieParent.Value, CanSpawn, _diContainer);
        }

        private void Update()
        {
            _timerMechanics.Update();
            _spawnMechanics.Update();
        }

        private void OnEnable()
        {
            _timerMechanics.OnEnable();
        }

        private void OnDisable()
        {
            _timerMechanics.OnDisable();
        }

        [Inject]
        public void Construct(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }
    }
}