using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class CharacterExperienceView : MonoBehaviour
    {
        [SerializeField] private Image experienceBar;
        [SerializeField] private GameObject fullExperienceBar;
        [SerializeField] private TMP_Text experienceText;

        public void SetExperience(string experienceAmountText, float experienceAmount, bool isFull)
        {
            experienceText.text = experienceAmountText;
            experienceBar.fillAmount = experienceAmount;
            fullExperienceBar.SetActive(isFull);
        }
    }
}