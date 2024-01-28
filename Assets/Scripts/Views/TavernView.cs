using UnityEngine;

namespace Views
{
    public class TavernView : MonoBehaviour
    {
        [SerializeField] private TavernCharacterView buttonPrefab;
        [SerializeField] private Transform tavernCharactersPrefab;

        public TavernCharacterView CreateTavernCharacterView()
        {
            var tavernCharacterView = Instantiate(buttonPrefab, tavernCharactersPrefab);
            return tavernCharacterView;
        }
    }
}