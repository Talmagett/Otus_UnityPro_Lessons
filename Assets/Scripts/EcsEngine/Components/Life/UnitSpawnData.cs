using Leopotam.EcsLite.Entities;
using UnityEngine;

namespace EcsEngine.Components.Life
{
    public struct UnitSpawnData
    {
        public Vector3 spawnPoint;
        public Quaternion rotation;
        public Entity spawnPrefab;
        public int playerId;
    }
}