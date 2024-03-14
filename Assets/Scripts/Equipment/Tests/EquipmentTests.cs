using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

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
        private const string ElectricBoots = "electricBoots";
        private const string FireSword = "fireSword";
        private const string IceShield = "iceShield";
        private const string PlateMail = "platemail";
        private const string DivineHelmet = "divineHelmet";

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
            CreateItemsAndAddToInventory();
        }

        private void CreateItemsAndAddToInventory()
        {
            var windBoots = new Item(WindBoots, ItemFlags.EQUIPPABLE | ItemFlags.EFFECTIBLE,
                new Stats(DamageStat, 10),
                new Stats(SpeedStat, 5),
                new EquipmentTypeComponent(EquipmentType.LEGS)
            );

            var electricBoots = new Item(ElectricBoots, ItemFlags.EQUIPPABLE | ItemFlags.EFFECTIBLE,
                new Stats(HealthStat, 10),
                new Stats(SpeedStat, 10),
                new Stats(DamageStat, 10),
                new EquipmentTypeComponent(EquipmentType.LEGS)
            );

            var fireSword = new Item(FireSword, ItemFlags.EQUIPPABLE | ItemFlags.EFFECTIBLE,
                new Stats(DamageStat, 32),
                new EquipmentTypeComponent(EquipmentType.RIGHT_HAND)
            );

            var iceShield = new Item(IceShield, ItemFlags.EQUIPPABLE | ItemFlags.EFFECTIBLE,
                new Stats(HealthStat, 24),
                new EquipmentTypeComponent(EquipmentType.LEFT_HAND)
            );

            var plateMail = new Item(PlateMail, ItemFlags.EQUIPPABLE | ItemFlags.EFFECTIBLE,
                new Stats(HealthStat, 56),
                new EquipmentTypeComponent(EquipmentType.BODY)
            );

            var divineHelmet = new Item(DivineHelmet, ItemFlags.EQUIPPABLE | ItemFlags.EFFECTIBLE,
                new Stats(HealthStat, 41),
                new EquipmentTypeComponent(EquipmentType.HEAD)
            );

            _inventory.AddItem(windBoots);
            _inventory.AddItem(electricBoots);
            _inventory.AddItem(fireSword);
            _inventory.AddItem(iceShield);
            _inventory.AddItem(plateMail);
            _inventory.AddItem(divineHelmet);
        }

        [Test]
        public void EquipItem()
        {
            _inventory.FindItem(WindBoots, out var item);
            _equipment.EquipItem(item);
            Assert.AreEqual(true, _equipment.HasItem(EquipmentType.LEGS));

            _inventory.FindItem(FireSword, out item);
            _equipment.EquipItem(item);
            Assert.AreEqual(true, _equipment.HasItem(EquipmentType.RIGHT_HAND));

            _inventory.FindItem(IceShield, out item);
            _equipment.EquipItem(item);
            Assert.AreEqual(true, _equipment.HasItem(EquipmentType.LEFT_HAND));

            _inventory.FindItem(PlateMail, out item);
            _equipment.EquipItem(item);
            Assert.AreEqual(true, _equipment.HasItem(EquipmentType.BODY));

            _inventory.FindItem(DivineHelmet, out item);
            _equipment.EquipItem(item);
            Assert.AreEqual(true, _equipment.HasItem(EquipmentType.HEAD));
        }

        [Test]
        public void UnequipItem()
        {
            _inventory.FindItem(WindBoots, out var item);
            _equipment.EquipItem(item);
            _equipment.UnequipItem(item);
            Assert.AreEqual(false, _equipment.HasItem(EquipmentType.LEGS));

            _inventory.FindItem(FireSword, out item);
            _equipment.EquipItem(item);
            _equipment.UnequipItem(item);
            Assert.AreEqual(false, _equipment.HasItem(EquipmentType.RIGHT_HAND));

            _inventory.FindItem(IceShield, out item);
            _equipment.EquipItem(item);
            _equipment.UnequipItem(item);
            Assert.AreEqual(false, _equipment.HasItem(EquipmentType.LEFT_HAND));

            _inventory.FindItem(PlateMail, out item);
            _equipment.EquipItem(item);
            _equipment.UnequipItem(item);
            Assert.AreEqual(false, _equipment.HasItem(EquipmentType.BODY));

            _inventory.FindItem(DivineHelmet, out item);
            _equipment.EquipItem(item);
            _equipment.UnequipItem(item);
            Assert.AreEqual(false, _equipment.HasItem(EquipmentType.HEAD));
        }

        [Test]
        public void SwapItems()
        {
            _inventory.FindItem(WindBoots, out var item);
            _equipment.EquipItem(item);
            Assert.AreEqual(true, _equipment.HasItem(EquipmentType.LEGS));

            _inventory.FindItem(ElectricBoots, out item);
            _equipment.EquipItem(item);
            Assert.AreEqual(true, _equipment.HasItem(EquipmentType.LEGS));
        }

        [Test]
        public void EquipTwice()
        {
            _inventory.FindItem(WindBoots, out var item);

            _equipment.EquipItem(item);
            _equipment.EquipItem(item);
            Assert.AreEqual(true, _equipment.HasItem(EquipmentType.LEGS));
        }

        [Test]
        public void UnequipTwice()
        {
            _inventory.FindItem(WindBoots, out var item);
            _equipment.EquipItem(item);

            _equipment.UnequipItem(item);
            _equipment.UnequipItem(item);
            Assert.AreEqual(false, _equipment.HasItem(EquipmentType.LEGS));
        }

        [Test]
        public void UnequipEmpty()
        {
            _inventory.FindItem(WindBoots, out var item);
            _equipment.UnequipItem(item);
            Assert.AreEqual(false, _equipment.HasItem(EquipmentType.LEGS));
        }

        [Test]
        public void WhenEquip_CheckStats()
        {
            _inventory.FindItem(WindBoots, out var item);

            var defaultSpeed = _character.GetStat(SpeedStat);
            var itemStatsArray = item.GetComponents<Stats>();
            var itemSpeedStat = itemStatsArray.FirstOrDefault(t => t.Name == SpeedStat);

            _equipment.EquipItem(item);
            var currentSpeed = _character.GetStat(SpeedStat);
            Assert.AreEqual(currentSpeed - defaultSpeed, itemSpeedStat.Value);
        }

        [Test]
        public void WhenUnequip_CheckStats()
        {
            _inventory.FindItem(WindBoots, out var item);

            var defaultSpeed = _character.GetStat(SpeedStat);
            var itemStatsArray = item.GetComponents<Stats>();
            var itemSpeedStat = itemStatsArray.FirstOrDefault(t => t.Name == SpeedStat);

            _equipment.EquipItem(item);
            var currentSpeed = _character.GetStat(SpeedStat);
            Assert.AreEqual(currentSpeed - defaultSpeed, itemSpeedStat.Value);

            _equipment.UnequipItem(item);

            currentSpeed = _character.GetStat(SpeedStat);
            Assert.AreEqual(defaultSpeed, currentSpeed);
        }
    }
}