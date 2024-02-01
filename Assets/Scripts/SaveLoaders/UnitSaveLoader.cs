using System.Linq;
using GameEngine;
using SaveSystem;
using UnityEngine;

namespace SaveLoaders
{
    public class UnitSaveLoader : SaveLoader<UnitData[], UnitManager>
    {
        protected override void SetupData(UnitManager unitManager, UnitData[] loadedUnitsDataArray)
        {
            var unitsOnLevel = unitManager.GetAllUnits().ToList();
            var loadedUnitsData = loadedUnitsDataArray.ToList();

            //intersect
            var result = 
                unitsOnLevel.Join(loadedUnitsData, levelUnit => levelUnit.Type, loadedUnit => loadedUnit.type,
                (levelUnit, loadedUnit) => new { levelUnit, loadedUnit });
            
            foreach (var unitPair in result.ToList())
            {
                unitPair.levelUnit.HitPoints = unitPair.loadedUnit.hitPoints;
                unitsOnLevel.Remove(unitPair.levelUnit);
                loadedUnitsData.Remove(unitPair.loadedUnit);
            }
            
            for (int i = unitsOnLevel.Count - 1; i >= 0; i--)
            {
                unitManager.DestroyUnit(unitsOnLevel[i]);
            }

            foreach (var unitData in loadedUnitsData)
            {
                var unitPrefab = unitManager.GetUnitPrefab(unitData.type);
                
                var position = JsonUtility.FromJson<Vector3>(unitData.position);
                var rotation = JsonUtility.FromJson<Vector3>(unitData.rotation);
                
                unitManager.SpawnUnit(unitPrefab,position,Quaternion.Euler(rotation));
            }
            Debug.Log($"units were loaded");
        }

        protected override UnitData[] ConvertToData(UnitManager unitManager)
        {
            var units = unitManager.GetAllUnits().ToArray();
            Debug.Log($"<color=green>{units.Length} units was saved</color>");
            var unitsData = new UnitData[units.Length];
            for (int i = 0; i < units.Length; i++)
            {
                unitsData[i].type = units[i].Type;
                unitsData[i].hitPoints = units[i].HitPoints;
                unitsData[i].position = JsonUtility.ToJson(units[i].Position);
                unitsData[i].rotation = JsonUtility.ToJson(units[i].Rotation);
            }
            return unitsData;
        }
    }
}