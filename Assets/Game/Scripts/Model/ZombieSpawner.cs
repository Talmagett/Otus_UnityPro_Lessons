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
        private void Awake()
        {
            _timerMechanics = new TimerMechanics(SpawnTimer,SpawnCooldown,CanSpawn);
            _spawnMechanics = new SpawnMechanics(zombiePrefab,zombieParent,CanSpawn);
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
            /*if(!CanSpawn.Value)
                DiContainer.Instantiate(_spawningObject, randPos, Quaternion.identity, _parent);
*/
            //_spawnMechanics.Update();
        }
    }
}