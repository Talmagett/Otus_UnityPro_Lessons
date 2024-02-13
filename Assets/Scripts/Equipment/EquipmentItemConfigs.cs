using UnityEngine;

namespace Sample
{
    [CreateAssetMenu(menuName = "Create EquipmentItemConfigs", fileName = "EquipmentItemConfigs", order = 0)]
    public class EquipmentItemConfigs : ScriptableObject
    {
        [field: SerializeField] public EquipmentType EquipmentType { get; private set; }
        [field: SerializeField] public ItemConfig ItemConfig { get; private set; }
    }
}