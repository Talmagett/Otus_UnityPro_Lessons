using System;

namespace Sample
{
    public class EquipmentEffector : IDisposable
    {
        private readonly Character _character;
        private readonly Equipment _equipment;

        public EquipmentEffector(Character character, Equipment equipment)
        {
            _character = character;
            _equipment = equipment;

            _equipment.OnItemEquipped += AddEffectToCharacter;
            _equipment.OnItemUnequipped += RemoveEffectFromCharacter;
        }

        public void Dispose()
        {
            _equipment.OnItemEquipped -= AddEffectToCharacter;
            _equipment.OnItemUnequipped -= RemoveEffectFromCharacter;
        }

        private void AddEffectToCharacter(Item obj)
        {
            var stat = obj.GetComponent<Stats>();
            if (stat is null)
                return;

            var statValue = _character.GetStat(stat.Name);

            _character.SetStat(stat.Name, statValue + stat.Value);
        }

        private void RemoveEffectFromCharacter(Item obj)
        {
            var stat = obj.GetComponent<Stats>();
            if (stat is null)
                return;

            var statValue = _character.GetStat(stat.Name);

            _character.SetStat(stat.Name, statValue - stat.Value);
        }
    }
}