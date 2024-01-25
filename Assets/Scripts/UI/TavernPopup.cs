using System.Collections.Generic;
using Models;
using UnityEngine;
using UnityEngine.Events;
using Views;
using Zenject;
using CharacterInfo = Models.CharacterInfo;

namespace UI
{
    public class TavernPopup : MonoBehaviour
    {
        [SerializeField] private TavernCharacterView buttonPrefab;
        [SerializeField] private Transform tavernCharactersPrefab;
        
        private CharacterPopup _characterPopup;
        private TavernCharacterService _tavernCharacterService;

        [Inject]
        public void Construct(CharacterPopup characterPopup,
            TavernCharacterService tavernCharacterService)
        {
            _tavernCharacterService = tavernCharacterService;
            _characterPopup = characterPopup;
            var characters = _tavernCharacterService.GetAllCharacters();
            BindButtons(characters);
        }

        private void BindButtons(IReadOnlyList<CharacterInfo> characters)
        {
            foreach (var characterInfo in characters)
            {
                var tavernCharacterView = Instantiate(buttonPrefab, tavernCharactersPrefab);
                var characterName = characterInfo.Name;
                var characterIcon = characterInfo.Icon;
                tavernCharacterView.SetTavernCharacterData(characterIcon, characterName);
                tavernCharacterView.SetOnCharacterChoose(OpenCharacterData(characterName));
            }
        }

        private UnityAction OpenCharacterData(string characterName)
        {
            return () => { _characterPopup.ShowCharacter(characterName); };
        }
    }
}