using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace Sample
{
    [TestFixture]
    public class EquipmentTests
    {
        private Character _character;
        private Inventory _inventory;
        private Equipment _equipment;
        private EquipmentEffector _equipmentEffector;
        
        [SetUp]
        public void Init()
        {
            _character = new Character(
                new KeyValuePair<string, int>("damage", 5),
                new KeyValuePair<string, int>("health", 20),
                new KeyValuePair<string, int>("speed", 10));
            _inventory = new Inventory();
            _equipment = new Equipment();
            _equipmentEffector = new EquipmentEffector(_character, _equipment);
        }

        [Test]
        public void CheckCharacter()
        {
            foreach (var (key, value) in _character.GetStats()) Debug.Log($"{key}:{value}");
            Assert.AreEqual(3, _character.GetStats().Length);
        }

        [Test]
        public void WhenBootsAdded_CheckInventory()
        {
            var windBoots = new Item("windBoots", ItemFlags.EQUPPABLE | ItemFlags.EFFECTIBLE,
                new Stats("speed", 5),
                    new EquipmentTypeComponent(EquipmentType.LEGS)
                );
            _inventory.AddItem(windBoots);
            Assert.AreEqual(1, _inventory.GetCount("windBoots"));
        }

        [Test]
        public void WhenBootsEquipped_CheckEquipment()
        {
            if (!_inventory.FindItem("windBoots", out var item)) return;

            _equipment.EquipItem(item);
            Assert.AreEqual(1, _equipment.HasItem(EquipmentType.LEGS));
        }

        [Test]
        public void WhenBootsUnequipped_CheckCount()
        {
            if (!_inventory.FindItem("windBoots", out var item)) return;

            _equipment.UnequipItem(item);
            Assert.AreEqual(0, _equipment.HasItem(EquipmentType.LEGS));
        }

        [Test]
        public void WhenBootsEquippedAndUnequipped_CheckEquipment()
        {
            if (!_inventory.FindItem("windBoots", out var item)) return;

            _equipment.EquipItem(item);
            Assert.AreEqual(1, _equipment.HasItem(EquipmentType.LEGS));

            _equipment.UnequipItem(item);
            Assert.AreEqual(0, _equipment.HasItem(EquipmentType.LEGS));
        }

        [Test]
        public void WhenBootsEquippedTwice_CheckEquipment()
        {
            if (!_inventory.FindItem("windBoots", out var item)) return;

            _equipment.EquipItem(item);

            _equipment.EquipItem(item);
            Assert.AreEqual(1, _equipment.HasItem(EquipmentType.LEGS));
        }

        [Test]
        public void CheckStats()
        {
            if (!_inventory.FindItem("windBoots", out var item)) return;

            Assert.AreEqual(10, _character.GetStat("speed"));

            _equipment.EquipItem(item);
            Assert.AreEqual(15, _character.GetStat("speed"));

            _equipment.UnequipItem(item);
            Assert.AreEqual(10, _character.GetStat("speed"));
        }
    }
}