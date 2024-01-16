using System;
using Models;
using Presenter;
using Presenters;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEngine;
using View;
using Zenject;
using CharacterInfo = Models.CharacterInfo;

namespace UI
{
    public class CharacterPopup : MonoBehaviour,IPopup
    {
        [SerializeField] private PlayerExperienceView playerExperienceView;
        [SerializeField] private PlayerLevelView playerLevelView;
        [SerializeField] private UserInfoView userInfoView;
        [SerializeField] private CharacterStatFabric characterStatFabric;
        
        [Space] 
        [SerializeField] private UnityEngine.UI.Button closeButton;
        
        private UserInfo _userInfo;
        private PlayerLevel _playerLevel;
        private CharacterInfo _characterInfo;
        
        private PlayerLevelPresenter _playerLevelPresenter;
        private UserInfoPresenter _userInfoPresenter;
        private CharacterInfoPresenter _characterInfoPresenter;
        
        private PopupManager _popupManager;

        [Inject]
        public void Construct(PopupManager popupManager)
        {
            _popupManager = popupManager;
            _popupManager.AddPopup(this);
        }
        private void Awake()
        {
            closeButton.onClick.AddListener(Hide);
        }

        private void OnDestroy()
        {
            closeButton.onClick.RemoveListener(Hide);
        }

        public void Hide()
        {            
            gameObject.SetActive(false);
        }

        public void Show(params object[] args)
        {
            foreach (var o in args)
            {
                if(o is UserInfo userInfo)
                    _userInfo = userInfo;
                if(o is PlayerLevel playerLevel)
                    _playerLevel = playerLevel;
                if(o is CharacterInfo characterInfo)        
                    _characterInfo = characterInfo;
            }
            
            _playerLevelPresenter = new PlayerLevelPresenter(_playerLevel,playerExperienceView,playerLevelView);
            _userInfoPresenter = new UserInfoPresenter(_userInfo,userInfoView);
            _characterInfoPresenter = new CharacterInfoPresenter(_characterInfo,characterStatFabric);
            gameObject.SetActive(true);
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