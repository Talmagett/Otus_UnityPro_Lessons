using Sample;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Equipment
{
    public class DebugEquipment : MonoBehaviour
    {
        [ReadOnly, ShowInInspector] private Character _character;
        [ReadOnly, ShowInInspector] private Inventory _inventory;

        private Equipment _equipment;
        
        [Inject]
        public void Construct(Character character, Inventory inventory)
        {
            _character = character;
            _inventory = inventory;
            
            _equipment = new Equipment(_character,_inventory);
        }
        
        [Button]
        public void EquipItem()
        {
            
        }
    }
}