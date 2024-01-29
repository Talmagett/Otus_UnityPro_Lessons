using System;
using JetBrains.Annotations;
using Models;
using Views;

namespace Presenters
{
    public interface ICharacterPopup
    {
        CharacterInfo CharacterInfo { get; }
        CharacterLevel CharacterLevel { get; }
        CharacterStatsInfo CharacterStatsInfo { get; }
    }

    [UsedImplicitly]
    public class CharacterPopupPresenter : ICharacterPopup, IDisposable
    {
        private readonly CharacterPopupView _characterPopupView;

        private readonly TavernCharacterService _tavernCharacterService;

        private CharacterInfoPresenter _characterInfoPresenter;

        private CharacterLevelPresenter _characterLevelPresenter;

        private CharacterStatsInfoPresenter _characterStatsInfoPresenter;

        public CharacterPopupPresenter(CharacterPopupView characterPopupView,
            TavernCharacterService tavernCharacterService)
        {
            _characterPopupView = characterPopupView;
            _tavernCharacterService = tavernCharacterService;
        }

        public CharacterInfo CharacterInfo { get; private set; }

        public CharacterLevel CharacterLevel { get; private set; }

        public CharacterStatsInfo CharacterStatsInfo { get; private set; }

        public void Dispose()
        {
            _characterInfoPresenter?.Dispose();
            _characterLevelPresenter?.Dispose();
            _characterStatsInfoPresenter?.Dispose();
        }

        public void ShowCharacter(string characterName)
        {
            CharacterInfo = _tavernCharacterService.GetCharacterInfoByName(characterName);
            CharacterLevel = _tavernCharacterService.GetCharacterLevel(characterName);
            CharacterStatsInfo = _tavernCharacterService.GetStats(characterName);

            _characterLevelPresenter = new CharacterLevelPresenter(CharacterLevel,
                _characterPopupView.CharacterExperienceView, _characterPopupView.CharacterLevelView);
            _characterInfoPresenter = new CharacterInfoPresenter(CharacterInfo, _characterPopupView.CharacterInfoView);
            _characterStatsInfoPresenter =
                new CharacterStatsInfoPresenter(CharacterStatsInfo, _characterPopupView.CharacterStatFactory);

            _characterPopupView.Show();
        }
    }
}