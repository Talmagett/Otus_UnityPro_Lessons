using System;
using System.Collections.Generic;
using System.Linq;
using Sample;
using Sirenix.OdinInspector;

namespace Equipment
{
    [Serializable]
    public sealed class Equipment
    {
        private readonly Character _character;
        private readonly Inventory _inventory;

        public Equipment(Character character, Inventory inventory)
        {
            _character = character;
            _inventory = inventory;
        }

        public event Action<Item> OnItemAdded;
        public event Action<Item> OnItemRemoved;
        public event Action<Item> OnItemChanged;
        
        private Dictionary<EquipmentType, Item> _equipment;
        
        public void Setup(params KeyValuePair<EquipmentType, Item>[] items)
        {
            foreach (var itemPair in items)
            {
                AddItem(itemPair.Key,itemPair.Value);
            }
        }

        private Item GetItem(EquipmentType type)
        {
            return !_equipment.ContainsKey(type) ? null : _equipment[type];
        }

        public bool TryGetItem(EquipmentType type, out Item result)
        {
            var hasItem = HasItem(type);
            result = GetItem(type);
            return hasItem;
        }

        public void RemoveItem(EquipmentType type, Item item)
        {
            if (_equipment.ContainsKey(type))
                _equipment.Remove(type);
        }

        public void AddItem(EquipmentType type, Item item)
        {
            if (_equipment.ContainsKey(type))
                _equipment[type] = item;
            
            _equipment.Add(type,item);
        }

        public void ChangeItem(EquipmentType type, Item item)
        {
            if (HasItem(type))
                _equipment[type] = item;
        }

        public bool HasItem(EquipmentType type)
        {
            return _equipment.ContainsKey(type);
        }

        public KeyValuePair<EquipmentType, Item>[] GetItems()
        {
            return _equipment.Select(item => new KeyValuePair<EquipmentType, Item>(item.Key, item.Value)).ToArray();
        }
    }
}