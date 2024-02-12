using System.Collections.Generic;
using Equipment;
using NUnit.Framework;
using Sample;

[TestFixture]
public class EquipmentTests
{
    [Test]
    public void WhenBootsAdded_CheckSpeedStat()
    {
        var character = new Character(new KeyValuePair<string, int>[]{new("speed",10)});
        
        var windBoots = new Item("windBoots",ItemFlags.EQUPPABLE|ItemFlags.EFFECTIBLE,null);
        var inventory = new Inventory(windBoots);

        var equipment = new Equipment.Equipment(character,inventory);
        
        equipment.AddItem(EquipmentType.LEGS,windBoots);
        Assert.True(character.GetStat("speed")==10);
    }
}