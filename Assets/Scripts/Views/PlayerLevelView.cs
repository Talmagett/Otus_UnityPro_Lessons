using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class PlayerLevelView : MonoBehaviour
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

        public void AddOnLevelUpListener(Action onClick)
        {
            levelUpButton.onClick.AddListener(() => onClick());
        }

        public void RemoveOnLevelUpListener(Action onClick)
        {
            levelUpButton.onClick.RemoveListener(() => onClick());
        }
    }
}