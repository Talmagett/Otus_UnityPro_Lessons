using UnityEngine;

namespace Game.UI
{
    public sealed class UIService : MonoBehaviour
    {
        [SerializeField] private HeroListView redPlayer;

        [SerializeField] private HeroListView bluePlayer;

        public HeroListView GetRedPlayer()
        {
            return redPlayer;
        }

        public HeroListView GetBluePlayer()
        {
            return bluePlayer;
        }
    }
}