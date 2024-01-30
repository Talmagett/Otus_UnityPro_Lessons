using System.Linq;
using GameEngine;
using SaveSystem;
using UnityEngine;

namespace SaveLoaders
{
    public class UnitSaveLoader : SaveLoader<UnitData[], UnitManager>
    {
        protected override void SetupData(UnitManager unitManager, UnitData[] data)
        {
            var units = unitManager.GetAllUnits().ToArray();
            
            /*unitManager.SpawnUnit(data.money);
            Debug.Log($"<color=green>Money loaded: {data.money}!</color>");*/
        }

        protected override UnitData[] ConvertToData(UnitManager unitManager)
        {
            var units = unitManager.GetAllUnits().ToArray();
            Debug.Log($"<color=green>{units.Length} was saved</color>");
            var unitsData = new UnitData[units.Length];
            for (int i = 0; i < units.Length; i++)
            {
                unitsData[i].type = units[i].Type;
                unitsData[i].hitPoints = units[i].HitPoints;
                unitsData[i].position = units[i].Position;
                unitsData[i].rotation = units[i].Rotation;
            }

            return unitsData;
        }
    }
}