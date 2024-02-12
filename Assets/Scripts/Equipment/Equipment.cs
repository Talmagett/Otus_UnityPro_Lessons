using System;
using System.Collections.Generic;
using Sample;

namespace Equipment
{
    //TODO: Реализовать экипировку
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

        public void Setup(KeyValuePair<EquipmentType, Item> items)
        {
        }

        public Item GetItem(EquipmentType type)
        {
            return null;
        }

        public bool TryGetItem(EquipmentType type, out Item result)
        {
            result = null;
                
            return true;
        }

        public void RemoveItem(EquipmentType type, Item item)
        {
        }

        public void AddItem(EquipmentType type, Item item)
        {
        }

        public void ChangeItem(EquipmentType type, Item item)
        {
        }

        public bool HasItem(EquipmentType type)
        {
            return true;
        }

        public KeyValuePair<EquipmentType, Item>[] GetItems()
        {
            return null;
        }
    }
}