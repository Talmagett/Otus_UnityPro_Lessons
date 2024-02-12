using System.Collections.Generic;
using Equipment;
using NUnit.Framework;
using Sample;
using UnityEngine;

[TestFixture]
public class EquipmentTests
{
    private Character _character;
    
    [SetUp]
    public void Init()
    {
        _character = new Character(
            new KeyValuePair<string, int>[]
            {
                new("damage", 5),
                new("health", 20),
                new("speed", 10),
            });
        
        foreach (var (key, value) in _character.GetStats())
        {
            Debug.Log($"{key}:{value}");
        }
    }
    
    [Test]
    public void WhenBootsAdded_CheckSpeedStat()
    {
        /*
        var windBoots = new Item("windBoots",ItemFlags.EQUPPABLE|ItemFlags.EFFECTIBLE,null);
        var inventory = new Inventory(windBoots);

        var equipment = new Equipment.Equipment(character,inventory);
        
        equipment.AddItem(EquipmentType.LEGS, windBoots);
        Assert.True(character.GetStat("speed")==10);*/
    }
}