using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

namespace View
{
    public class PlayerExperienceView:MonoBehaviour
    {
        [SerializeField] private Image experienceBar;
        [SerializeField] private GameObject fullExperienceBar;
        [SerializeField] private TMP_Text experienceText;
        
        public void SetExperience(int currentExperience, int requireExperience)
        {
            experienceText.text = $"XP: {currentExperience} / {requireExperience}";
            experienceBar.fillAmount = (float)currentExperience / requireExperience;
            fullExperienceBar.SetActive(currentExperience >= requireExperience);
        }
    }
}