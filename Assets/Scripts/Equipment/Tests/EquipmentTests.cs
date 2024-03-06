using System;
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

        private const string WindBoots = "windBoots";
        
        private const string SpeedStat = "speed";
        private const string DamageStat = "damage";
        private const string HealthStat = "health";
        
        [SetUp]
        public void Init()
        {
            _character = new Character(
                new KeyValuePair<string, int>(DamageStat, 5),
                new KeyValuePair<string, int>(HealthStat, 20),
                new KeyValuePair<string, int>(SpeedStat, 10));
            _inventory = new Inventory();
            _equipment = new Equipment();
            _equipmentEffector = new EquipmentEffector(_character, _equipment);
            
            var windBoots = new Item(WindBoots, ItemFlags.EQUPPABLE | ItemFlags.EFFECTIBLE,
                new Stats(DamageStat,10),
                new Stats(SpeedStat, 5),
                new EquipmentTypeComponent(EquipmentType.LEGS)
            );
            _inventory.AddItem(windBoots);
        }
        
        [Test]
        public void WhenBootsAdded_CheckInventory()
        {
            Assert.AreEqual(1, _inventory.GetCount(WindBoots));
        }

        [Test]
        public void WhenBootsEquippedAndUnequipped_CheckEquipment()
        {
            _inventory.FindItem(WindBoots, out var item);

            _equipment.EquipItem(item);
            Assert.AreEqual(true, _equipment.HasItem(EquipmentType.LEGS));

            _equipment.UnequipItem(item);
            Assert.AreEqual(false, _equipment.HasItem(EquipmentType.LEGS));
        }

        [Test]
        public void WhenBootsEquippedAndUnequippedTwice_CheckEquipment()
        {
            _inventory.FindItem(WindBoots, out var item);

            _equipment.EquipItem(item);
            _equipment.EquipItem(item);
            Assert.AreEqual(true, _equipment.HasItem(EquipmentType.LEGS));
            
            _equipment.UnequipItem(item);
            _equipment.UnequipItem(item);
            Assert.AreEqual(false, _equipment.HasItem(EquipmentType.LEGS));
        }

        [Test]
        public void CheckStats()
        {
            _inventory.FindItem(WindBoots, out var item);
            var defaultSpeed =_character.GetStat(SpeedStat);
            var statsArray = item.GetComponents<Stats>();
            Stats itemSpeed = null;
            foreach (var stat in statsArray)
            {
                if (stat.Name == SpeedStat)
                    itemSpeed = stat;
            }

            _equipment.EquipItem(item);
            var currentSpeed = _character.GetStat(SpeedStat);
            Assert.AreEqual(currentSpeed-defaultSpeed, itemSpeed.Value);

            _equipment.UnequipItem(item);
            
            currentSpeed = _character.GetStat(SpeedStat);
            Assert.AreEqual(defaultSpeed, currentSpeed);
        }
    }
}