using System;
using System.Collections.Generic;
using System.Linq;

namespace Models
{
    public class TavernCharacterService
    {
        private readonly CharacterData[] _charactersData;

        public TavernCharacterService(CharacterData[] charactersData)
        {
            _charactersData = charactersData;
        }

        public IReadOnlyList<CharacterInfo> GetAllCharacters()
        {
            var characterInfos = new CharacterInfo[_charactersData.Length];
            for (var i = 0; i < _charactersData.Length; i++)
            {
                var characterData = _charactersData[i];
                characterInfos[i] =
                    new CharacterInfo(characterData.Name, characterData.Description, characterData.Icon);
            }

            return characterInfos;
        }

        public CharacterInfo GetCharacterInfoByName(string name)
        {
            var characterData = _charactersData.FirstOrDefault(t => t.Name == name);
            if (characterData is null)
                throw new NullReferenceException($"No character with name {name}");

            var characterInfo = new CharacterInfo(characterData.Name, characterData.Description, characterData.Icon);
            return characterInfo;
        }

        public CharacterLevel GetCharacterLevel(string characterName)
        {
            var characterData = GetCharacterDataByName(characterName);
            var characterLevel = new CharacterLevel(characterData.Level);
            return characterLevel;
        }

        public CharacterStatsInfo GetStats(string characterName)
        {
            var characterData = GetCharacterDataByName(characterName);
            var statsInfo = new CharacterStatsInfo();
            foreach (var statData in characterData.Stats)
                statsInfo.AddStat(new CharacterStat(statData.Name, statData.Value));
            return statsInfo;
        }

        private CharacterData GetCharacterDataByName(string name)
        {
            var characterData = _charactersData.FirstOrDefault(t => t.Name == name);
            if (characterData is null)
                throw new NullReferenceException($"No character with name {name}");
            return characterData;
        }
    }
}