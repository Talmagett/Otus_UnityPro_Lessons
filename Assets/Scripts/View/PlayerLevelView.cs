using System;
using TMPro;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UI;

namespace View
{
    public class PlayerLevelView:MonoBehaviour
    {
        [SerializeField] private TMP_Text levelText;
        [SerializeField] private Button levelUpButton;

        public void SetLevel(int level)
        {
            levelText.text = $"Level: {level}";
        }

        public void SetVisibleLevelUpButton(bool isActive)
        {
            levelUpButton.gameObject.SetActive(isActive);
        }

        public void AddOnLevelUpListener(Action onClick)
        {
            levelUpButton.onClick.AddListener(()=>onClick());
        }

        public void RemoveOnLevelUpListener(Action onClick)
        {
            levelUpButton.onClick.RemoveListener(()=>onClick());
        }
    }
}