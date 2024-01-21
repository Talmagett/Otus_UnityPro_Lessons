using Models;
using Sirenix.Utilities;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;
using CharacterInfo = Models.CharacterInfo;

namespace UI
{
    public class TavernPopup : MonoBehaviour, IPopup
    {
        [SerializeField] private CharacterData[] characters;
        [SerializeField] private Button[] buttons;
        private CharacterInfo _characterInfo;
        private PlayerLevel _playerLevel;

        private PopupManager _popupManager;

        private UserInfo _userInfo;

        private void Awake()
        {
            for (var i = 0; i < buttons.Length; i++)
            {
                var character = characters[i];
                //вот тут хочу вызвать функцию с параметром, знаю что стоит использовать без ()=>
                buttons[i].onClick.AddListener(OpenCharacterData(character));
            }
        }

        public void Hide()
        {
        }

        public void Show(params object[] args)
        {
        }

        [Inject]
        public void Construct(PopupManager popupManager)
        {
            _popupManager = popupManager;
            _popupManager.AddPopup(this);
        }

        private UnityAction OpenCharacterData(CharacterData characterData)
        {
            return () =>
            {
                _userInfo = new UserInfo(characterData.UserName, characterData.Description, characterData.Icon);

                _playerLevel = new PlayerLevel(characterData.Level);
                if (_characterInfo != null)
                {
                    var prevCharacterStats = _characterInfo.GetStats();
                    prevCharacterStats.ForEach(t => _characterInfo.RemoveStat(t));
                }

                _characterInfo = new CharacterInfo();

                _popupManager.ShowPopup(typeof(CharacterPopup), _userInfo, _playerLevel, _characterInfo);


                foreach (var statData in characterData.Stats)
                    _characterInfo.AddStat(new CharacterStat(statData.Name, statData.Value));
            };
        }
    }
}