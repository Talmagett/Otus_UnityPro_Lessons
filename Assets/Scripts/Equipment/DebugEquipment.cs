using System;
using Sample;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Equipment
{
    public class DebugEquipment : MonoBehaviour
    {
        private Equipment _equipment;

        [Inject]
        public void Construct(Equipment equipment)
        {
            _equipment = equipment;
        }

        [Button]
        public void EquipItem(EquipmentItemConfigs equipmentItemConfigs)
        {
            _equipment.EquipItem(equipmentItemConfigs.EquipmentType,equipmentItemConfigs.ItemConfig.item.Clone());
        }
        
        [Button]
        public void UnequipItem(EquipmentItemConfigs equipmentItemConfigs)
        {
            _equipment.UnequipItem(equipmentItemConfigs.EquipmentType,equipmentItemConfigs.ItemConfig.item.Clone());
        }
    }
}