using Models;
using UnityEngine;

namespace View
{
    public class CharacterStatFabric : MonoBehaviour
    {
        [SerializeField] private Transform statsParent;
        [SerializeField] private CharacterStatView characterStatViewPrefab;

        public CharacterStatView CreateStat(CharacterStat stat)
        {
            var characterStatView = Instantiate(characterStatViewPrefab, statsParent);
            characterStatView.SetStatData(stat.Name,stat.Value);
            return characterStatView;
        }

        public void DestroyStat(CharacterStatView characterStatView)
        {
            Destroy(characterStatView.transform.gameObject);
        }
    }
}