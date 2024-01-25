using TMPro;
using UnityEngine;

namespace Views
{
    public class CharacterStatView : MonoBehaviour
    {
        [SerializeField] private TMP_Text statText;

        public void SetStatData(string stat)
        {
            statText.text = stat;
        }
    }
}