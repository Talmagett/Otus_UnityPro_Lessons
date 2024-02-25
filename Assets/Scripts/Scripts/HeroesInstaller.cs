using Lessons.Entities.Config;
using UI;
using UnityEngine;
using Zenject;

namespace Scripts
{
    public class HeroesInstaller : MonoInstaller
    {
        [Header("Configs")]
        [SerializeField] private Hero[] player1Heroes;
        [SerializeField] private Hero[] player2Heroes;
        
        [Space]
        [SerializeField] private HeroListView player1HeroesView;
        [SerializeField] private HeroListView player2HeroesView;
        
        public override void InstallBindings()
        {
            
        }
    }
}