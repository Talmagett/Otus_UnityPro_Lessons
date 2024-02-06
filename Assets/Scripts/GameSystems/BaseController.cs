using System;
using EcsEngine.Components.Life;
using EcsEngine.Components.Tags;
using EcsEngine.Components.Transform;
using Leopotam.EcsLite.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GameSystems
{
    public class BaseController : MonoBehaviour
    {
        [SerializeField] [EnumToggleButtons] private PlayerType playerType;

        [SerializeField] private Entity redBase;

        [SerializeField] private Entity blueBase;

        [SerializeField] [EnumToggleButtons] private SpawningUnitType spawningUnitType;

        [SerializeField] private Entity archerPrefab;

        [SerializeField] private Entity swordsmanPrefab;

        [Button]
        public void Spawn()
        {
            var unitSpawnData = new UnitSpawnData();
            var baseEntity = playerType switch
            {
                PlayerType.Blue => blueBase,
                PlayerType.Red => redBase,
                _ => throw new ArgumentOutOfRangeException()
            };

            baseEntity.SetData(new SpawnRequest());

            unitSpawnData.spawnPrefab = spawningUnitType switch
            {
                SpawningUnitType.Swordsman => swordsmanPrefab,
                SpawningUnitType.Archer => archerPrefab,
                _ => throw new ArgumentOutOfRangeException()
            };

            unitSpawnData.spawnPoint = baseEntity.GetData<SpawnPosition>().value;
            unitSpawnData.rotation = baseEntity.GetData<Rotation>().value;
            unitSpawnData.playerId = baseEntity.GetData<PlayerID>().value;

            baseEntity.SetData(unitSpawnData);
        }

        private enum PlayerType
        {
            Red,
            Blue
        }

        private enum SpawningUnitType
        {
            Swordsman,
            Archer
        }
    }
}