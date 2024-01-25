using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class CharacterInfoView : MonoBehaviour
    {
        [SerializeField] private TMP_Text nameText;
        [SerializeField] private TMP_Text descriptionText;
        [SerializeField] private Image userIcon;

        public void SetName(string characterName)
        {
            nameText.text = characterName;
        }

        public void SetDescription(string description)
        {
            descriptionText.text = description;
        }

        public void SetIcon(Sprite characterIcon)
        {
            userIcon.sprite = characterIcon;
        }
    }
}