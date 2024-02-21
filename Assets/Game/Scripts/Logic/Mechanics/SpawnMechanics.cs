using Data.Variable;
using UnityEngine;

namespace Logic.Mechanics
{
    public class SpawnMechanics
    {
        private readonly GameObject _spawningObject;
        private readonly Transform _parent;
        private readonly IAtomicVariable<bool> _canSpawn;

        public SpawnMechanics(GameObject spawningObject,Transform parent, IAtomicVariable<bool> canSpawn)
        {
            _spawningObject = spawningObject;
            _parent = parent;
            _canSpawn = canSpawn;
        }

        public void Update()
        {
            if (!_canSpawn.Value)
                return;
            var randPos = Random.insideUnitSphere * 10;
            randPos.y = 0;
            GameObject.Instantiate(_spawningObject, randPos, Quaternion.identity, _parent);
            _canSpawn.Value = false;
        }
    }
}