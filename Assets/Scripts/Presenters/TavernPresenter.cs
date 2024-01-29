using JetBrains.Annotations;
using Models;
using UnityEngine.Events;
using Views;

namespace Presenters
{
    [UsedImplicitly]
    public class TavernPresenter
    {
        private readonly CharacterPopupPresenter _characterPopupPresenter;
        private readonly TavernCharacterService _tavernCharacterService;
        private readonly TavernView _tavernView;

        public TavernPresenter(TavernView tavernView, CharacterPopupPresenter characterPopupPresenter,
            TavernCharacterService tavernCharacterService)
        {
            _tavernView = tavernView;
            _characterPopupPresenter = characterPopupPresenter;
            _tavernCharacterService = tavernCharacterService;

            CreateTavernCharacters();
        }

        private void CreateTavernCharacters()
        {
            var characters = _tavernCharacterService.GetAllCharacters();

            foreach (var characterInfo in characters)
            {
                var tavernCharacterView = _tavernView.CreateTavernCharacterView();
                var characterName = characterInfo.Name;
                var characterIcon = characterInfo.Icon;
                tavernCharacterView.SetTavernCharacterData(characterIcon, characterName);
                tavernCharacterView.SetOnCharacterChoose(OpenCharacterData(characterName));
            }
        }

        private UnityAction OpenCharacterData(string characterName)
        {
            return () => { _characterPopupPresenter.ShowCharacter(characterName); };
        }
    }
}