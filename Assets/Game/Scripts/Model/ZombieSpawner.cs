using Data.Variable;
using Logic.Data;
using Logic.Mechanics.LifeMechanics;
using Logic.Mechanics.TimeMechanics;
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

        private DiContainer _diContainer;

        //Logic
        private SpawnMechanics _spawnMechanics;
        private TimerMechanics _timerMechanics;

        private void Awake()
        {
            _timerMechanics = new TimerMechanics(SpawnTimer);
            _spawnMechanics = new SpawnMechanics(zombiePrefab.Value, zombieParent.Value, SpawnTimer.FinishEvent,
                _diContainer);
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

        [Inject]
        public void Construct(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }
    }
}