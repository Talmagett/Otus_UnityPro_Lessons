using System.Collections.Generic;
using Equipment.EquipmentEffector;
using Sample;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        /*Dictionary<string, int> stats = new Dictionary<string, int>()
        {
            {"damage", 5},
            {"health", 20},
            {"speed", 10},
        };*/
        var stats = new KeyValuePair<string, int>[]
        {
            new("damage", 10),
            new("health", 10),
            new("speed", 10)
        };
        Container.Bind<Character>().AsSingle().WithArguments(stats).NonLazy();

        Container.Bind<Inventory>().AsSingle().NonLazy();
        Container.Bind<Equipment.Equipment>().AsSingle().NonLazy();
        Container.Bind<EquipmentEffector>().AsSingle().NonLazy();
    }
}