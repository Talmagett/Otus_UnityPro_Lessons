using System;
using Presenter;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEngine;
using UnityEngine.Serialization;
using View;

namespace UI
{
    public class CharacterPopup:MonoBehaviour
    {
        [SerializeField] private PlayerExperienceView playerExperienceView;
        [SerializeField] private PlayerLevelView playerLevelView;
        [SerializeField] private UserInfoView userInfoView;
        [FormerlySerializedAs("characterInfoView")] [SerializeField] private CharacterStatFabric characterStatFabric;
        
        [Space]
        private PlayerLevel _playerLevel;
        private CharacterStat _characterStat;
        private UserInfo _userInfo;
        private CharacterInfo _characterInfo;
        
        private PlayerLevelPresenter _playerLevelPresenter;
        private UserInfoPresenter _userInfoPresenter;
        private CharacterInfoPresenter _characterInfoPresenter;
        private void Awake()
        {
            _playerLevel = new PlayerLevel();
            _userInfo = new UserInfo();
            _characterInfo = new CharacterInfo();
            _playerLevelPresenter = new PlayerLevelPresenter(_playerLevel,playerExperienceView,playerLevelView);
            _userInfoPresenter = new UserInfoPresenter(_userInfo,userInfoView);
            _characterInfoPresenter = new CharacterInfoPresenter(_characterInfo,characterStatFabric);
        }

        [Button]
        public void SetUserData(string userName, string description, Sprite icon)
        {
            if(!userName.IsNullOrWhitespace())
                _userInfo.ChangeName(userName);
            if(!description.IsNullOrWhitespace())
                _userInfo.ChangeDescription(description);
            if(icon!=null)
                _userInfo.ChangeIcon(icon);
        }
        
        [Button]
        public void AddExperience(int xpValue)
        {
            _playerLevel.AddExperience(xpValue);
        }

        [Button]
        public void AddStat(string statName,int value)
        {
            try
            {
                _characterInfo.GetStat(statName);
            }
            catch (Exception e)
            {
                _characterInfo.AddStat(new CharacterStat(statName,value));
            }
        }
        
        [Button]
        public void RemoveStat(string statName)
        {
            try
            {
                var stat= _characterInfo.GetStat(statName);
                _characterInfo.RemoveStat(stat);
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
                var stat = _characterInfo.GetStat(statName);
                stat.ChangeValue(newValue);
            }
            catch (Exception e)
            {
                print("no such Stat");
            }
        }
    }
}