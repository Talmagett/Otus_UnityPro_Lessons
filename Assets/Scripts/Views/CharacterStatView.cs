using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace View
{
    public class CharacterStatView : MonoBehaviour
    {
        [SerializeField] private TMP_Text statText;

        [Button("Set Stat")]
        public void SetStatData(string statName, int statValue)
        {
            statText.text = $"{statName} : {statValue}";
        }
    }
}