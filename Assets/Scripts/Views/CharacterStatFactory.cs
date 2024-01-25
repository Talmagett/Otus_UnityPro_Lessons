using Models;
using UnityEngine;

namespace Views
{
    public class CharacterStatFactory : MonoBehaviour
    {
        [SerializeField] private Transform statsParent;
        [SerializeField] private CharacterStatView characterStatViewPrefab;

        public CharacterStatView CreateStat(CharacterStat stat)
        {
            var characterStatView = Instantiate(characterStatViewPrefab, statsParent);

            characterStatView.SetStatData($"{stat.Name} : {stat.Value}");
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