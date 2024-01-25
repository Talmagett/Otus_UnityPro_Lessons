using System;
using Models;
using Presenters;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Views;
using Zenject;
using CharacterInfo = Models.CharacterInfo;

namespace UI
{
    public class CharacterPopup : MonoBehaviour
    {
        [SerializeField] private CharacterExperienceView characterExperienceView;
        [SerializeField] private CharacterLevelView characterLevelView;
        [SerializeField] private CharacterInfoView characterInfoView;

        [SerializeField] private CharacterStatFactory characterStatFactory;

        [Space] [SerializeField] private Button closeButton;

        private CharacterInfo _characterInfo;
        private CharacterInfoPresenter _characterInfoPresenter;
        private CharacterLevel _characterLevel;

        private CharacterLevelPresenter _characterLevelPresenter;

        private CharacterStatsInfo _characterStatsInfo;
        private CharacterStatsInfoPresenter _characterStatsInfoPresenter;

        private TavernCharacterService _tavernCharacterService;

        private void Awake()
        {
            closeButton.onClick.AddListener(Hide);
        }

        private void OnDestroy()
        {
            closeButton.onClick.RemoveListener(Hide);
        }

        [Inject]
        public void Construct(TavernCharacterService tavernCharacterService)
        {
            _tavernCharacterService = tavernCharacterService;
        }

        public void ShowCharacter(string characterName)
        {
            _characterInfo = _tavernCharacterService.GetCharacterInfoByName(characterName);
            _characterLevel = _tavernCharacterService.GetCharacterLevel(characterName);
            _characterStatsInfo = _tavernCharacterService.GetStats(characterName);
            _characterLevelPresenter =
                new CharacterLevelPresenter(_characterLevel, characterExperienceView, characterLevelView);
            _characterInfoPresenter = new CharacterInfoPresenter(_characterInfo, characterInfoView);
            _characterStatsInfoPresenter = new CharacterStatsInfoPresenter(_characterStatsInfo, characterStatFactory);
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        [Button]
        public void SetUserData(string userName, string description, Sprite icon)
        {
            if (!userName.IsNullOrWhitespace())
                _characterInfo.ChangeName(userName);
            if (!description.IsNullOrWhitespace())
                _characterInfo.ChangeDescription(description);
            if (icon != null)
                _characterInfo.ChangeIcon(icon);
        }

        [Button]
        public void AddExperience(int xpValue)
        {
            _characterLevel.AddExperience(xpValue);
        }

        [Button]
        public void AddStat(string statName, int value)
        {
            try
            {
                _characterStatsInfo.GetStat(statName);
            }
            catch (Exception e)
            {
                _characterStatsInfo.AddStat(new CharacterStat(statName, value));
            }
        }

        [Button]
        public void RemoveStat(string statName)
        {
            try
            {
                var stat = _characterStatsInfo.GetStat(statName);
                _characterStatsInfo.RemoveStat(stat);
            }
            catch (Exception e)
            {
                print("no such Stat");
            }
        }

        [Button]
        public void ChangeStatValue(string statName, int newValue)
        {
            try
            {
                var stat = _characterStatsInfo.GetStat(statName);
                stat.ChangeValue(newValue);
            }
            catch (Exception e)
            {
                print("no such Stat");
            }
        }
    }
}