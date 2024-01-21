using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class PlayerExperienceView : MonoBehaviour
    {
        [SerializeField] private Image experienceBar;
        [SerializeField] private GameObject fullExperienceBar;
        [SerializeField] private TMP_Text experienceText;

        public void SetExperienceText(string experience)
        {
            experienceText.text = experience;
        }

        public void SetExperienceFillAmount(float percent)
        {
            experienceBar.fillAmount = percent;
        }
        
        public void SetFullExperienceBarActive(bool active)
        {
            fullExperienceBar.SetActive(active);
        }
    }
}