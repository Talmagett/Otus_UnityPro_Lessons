using System;
using Presenters;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class CharacterPopupView : MonoBehaviour
    {
        [SerializeField] private GameObject popupGameObject;
        [SerializeField] private Button closeButton;
        [field:SerializeField, Space] public CharacterExperienceView CharacterExperienceView {get; private set;}
        [field:SerializeField] public CharacterLevelView CharacterLevelView {get; private set;}
        [field:SerializeField] public CharacterInfoView CharacterInfoView {get; private set;}
        [field:SerializeField] public CharacterStatFactory CharacterStatFactory {get; private set;}
        
        private void Awake()
        {
            closeButton.onClick.AddListener(Hide);
        }

        private void OnDestroy()
        {
            closeButton.onClick.RemoveListener(Hide);
        }

        public void Show()
        {
            popupGameObject.SetActive(true);
        }

        private void Hide()
        {
            popupGameObject.SetActive(false);
        }
    }
}