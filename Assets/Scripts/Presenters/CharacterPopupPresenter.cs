using System;
using JetBrains.Annotations;
using Models;
using Views;

namespace Presenters
{
    [UsedImplicitly]
    public class CharacterPopupPresenter : IDisposable
    {
        private readonly CharacterPopupView _characterPopupView;

        public CharacterPopupPresenter(CharacterPopupView characterPopupView,
            TavernCharacterService tavernCharacterService)
        {
            _characterPopupView = characterPopupView;
            _tavernCharacterService = tavernCharacterService;
        }

        private CharacterInfo _characterInfo;
        private CharacterInfoPresenter _characterInfoPresenter;
        private CharacterLevel _characterLevel;

        private CharacterLevelPresenter _characterLevelPresenter;

        private CharacterStatsInfo _characterStatsInfo;
        private CharacterStatsInfoPresenter _characterStatsInfoPresenter;

        private readonly TavernCharacterService _tavernCharacterService;

        public void ShowCharacter(string characterName)
        {
            _characterInfo = _tavernCharacterService.GetCharacterInfoByName(characterName);
            _characterLevel = _tavernCharacterService.GetCharacterLevel(characterName);
            _characterStatsInfo = _tavernCharacterService.GetStats(characterName);


            _characterLevelPresenter = new CharacterLevelPresenter(_characterLevel,
                _characterPopupView.CharacterExperienceView, _characterPopupView.CharacterLevelView);
            _characterInfoPresenter = new CharacterInfoPresenter(_characterInfo, _characterPopupView.CharacterInfoView);
            _characterStatsInfoPresenter =
                new CharacterStatsInfoPresenter(_characterStatsInfo, _characterPopupView.CharacterStatFactory);

            _characterPopupView.Show();
        }

        public void Dispose()
        {
            _characterInfoPresenter?.Dispose();
            _characterLevelPresenter?.Dispose();
            _characterStatsInfoPresenter?.Dispose();
        }
    }
}