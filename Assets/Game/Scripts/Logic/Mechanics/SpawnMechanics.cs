using Data.Variable;
using UnityEngine;
using Zenject;

namespace Logic.Mechanics
{
    public class SpawnMechanics
    {
        private readonly GameObject _spawningObject;
        private readonly Transform _parent;
        private readonly IAtomicVariable<bool> _canSpawn;
        private readonly DiContainer _diContainer;

        public SpawnMechanics(GameObject spawningObject,Transform parent, IAtomicVariable<bool> canSpawn, DiContainer diContainer)
        {
            _spawningObject = spawningObject;
            _parent = parent;
            _canSpawn = canSpawn;
            _diContainer = diContainer;
        }

        public void Update()
        {
            if (!_canSpawn.Value)
                return;
            var randPos = Random.insideUnitSphere * 10;
            randPos.y = 0;
            _diContainer.InstantiatePrefab(_spawningObject, randPos, Quaternion.identity, _parent);
            _canSpawn.Value = false;
        }
    }
}