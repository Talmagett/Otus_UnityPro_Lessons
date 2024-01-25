using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Views
{
    public class TavernCharacterView : MonoBehaviour
    {
        [SerializeField] private Image characterImage;
        [SerializeField] private TMP_Text characterNameText;
        [SerializeField] private Button chooseButton;

        private void OnDestroy()
        {
            chooseButton.onClick.RemoveAllListeners();
        }

        public void SetTavernCharacterData(Sprite characterIcon, string characterName)
        {
            characterImage.sprite = characterIcon;
            characterNameText.text = characterName;
        }

        public void SetOnCharacterChoose(UnityAction onClick)
        {
            chooseButton.onClick.AddListener(onClick);
        }
    }
}