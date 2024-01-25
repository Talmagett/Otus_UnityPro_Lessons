using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Views
{
    public class CharacterLevelView : MonoBehaviour
    {
        [SerializeField] private TMP_Text levelText;
        [SerializeField] private Button levelUpButton;

        public void SetLevel(string text)
        {
            levelText.text = text;
        }

        public void SetVisibleLevelUpButton(bool isActive)
        {
            levelUpButton.gameObject.SetActive(isActive);
        }

        public void AddOnLevelUpListener(UnityAction onClick)
        {
            levelUpButton.onClick.AddListener(onClick);
        }

        public void RemoveOnLevelUpListener(UnityAction onClick)
        {
            levelUpButton.onClick.RemoveListener(onClick);
        }
    }
}