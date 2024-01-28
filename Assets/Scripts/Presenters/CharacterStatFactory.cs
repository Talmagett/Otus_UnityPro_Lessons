using Models;
using UnityEngine;
using Views;

namespace Presenters
{
    public class CharacterStatFactory : MonoBehaviour
    {
        [SerializeField] private Transform statsParent;
        [SerializeField] private CharacterStatView characterStatViewPrefab;

        public CharacterStatView CreateStat()
        {
            var characterStatView = Instantiate(characterStatViewPrefab, statsParent);
            return characterStatView;
        }

        public void ClearStats()
        {
            while (statsParent.childCount>0)
            {
                DestroyImmediate(statsParent.GetChild(0).gameObject);
            }
        }

        public void DestroyStat(CharacterStatView characterStatView)
        {
            Destroy(characterStatView.transform.gameObject);
        }
    }
}