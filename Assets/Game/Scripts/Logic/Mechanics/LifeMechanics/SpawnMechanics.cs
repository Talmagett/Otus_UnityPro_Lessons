using Data.Event;
using Data.Variable;
using UnityEngine;
using Zenject;

namespace Logic.Mechanics
{
    public class SpawnMechanics
    {
        private readonly IAtomicEvent _onSpawn;
        private readonly DiContainer _diContainer;
        private readonly Transform _parent;
        private readonly GameObject _spawningObject;

        public SpawnMechanics(GameObject spawningObject, Transform parent, IAtomicEvent onSpawn,
            DiContainer diContainer)
        {
            _spawningObject = spawningObject;
            _parent = parent;
            _onSpawn = onSpawn;
            _diContainer = diContainer;
        }

        public void OnEnable()
        {
            _onSpawn.Subscribe(Spawn);
        }

        public void OnDisable()
        {
            _onSpawn.Unsubscribe(Spawn);
        }
        
        private void Spawn()
        {
            var randPos = Random.insideUnitSphere * 10;
            randPos.y = 0;
            _diContainer.InstantiatePrefab(_spawningObject, randPos, Quaternion.identity, _parent);
        }
    }
}