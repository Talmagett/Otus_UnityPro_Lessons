using System;
using System.Linq;
using Game.Entities.Config;
using Game.UI;
using UnityEngine;
using Zenject;

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
        var player1Views = player1HeroesView.GetViews().ToArray();
        var player2Views = player2HeroesView.GetViews().ToArray();
            
        if (player1Heroes.Length>4||player2Heroes.Length>4)
        {
            throw new Exception("Count of init heroes is more than 4");
        }

        for (int i = 0; i < player1Views.Length; i++)
        {
            player1Views[i].SetIcon(player1Heroes[i].Icon);
            player1Views[i].SetStats($"{player1Heroes[i].AttackDamage}/{player1Heroes[i].Health}");
        }

        for (int i = 0; i < player2Views.Length; i++)
        {
            player2Views[i].SetIcon(player2Heroes[i].Icon);
            player2Views[i].SetStats($"{player2Heroes[i].AttackDamage}/{player2Heroes[i].Health}");
        }
    }
}