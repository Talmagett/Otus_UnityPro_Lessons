using TMPro;
using UnityEngine;
using Sirenix.OdinInspector;
namespace View
{
    public class PlayerLevelView:MonoBehaviour
    {
        [SerializeField] private TMP_Text levelText;
        
        [Button("Set Level")]
        public void SetLevel(int level)
        {
            levelText.text = $"Level: {level}";
        }
    }
}