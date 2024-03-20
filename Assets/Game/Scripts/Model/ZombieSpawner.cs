using Data.Variable;
using Logic;
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
        public TimerData SpawnTimer;
        
        //Logic
        private SpawnMechanics _spawnMechanics;
        private TimerMechanics _timerMechanics;

        private DiContainer _diContainer;

        [Inject]
        public void Construct(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }
        
        private void Awake()
        {
            _timerMechanics = new TimerMechanics(SpawnTimer);
            _spawnMechanics = new SpawnMechanics(zombiePrefab.Value, zombieParent.Value, SpawnTimer.FinishEvent, _diContainer);
        }

        private void Update()
        {
            _timerMechanics.Update();
        }

        private void OnEnable()
        {
            _timerMechanics.OnEnable();
            _spawnMechanics.OnEnable();
        }

        private void OnDisable()
        {
            _timerMechanics.OnDisable();
            _spawnMechanics.OnDisable();
        }
    }
}