using System.Collections.Generic;
using Sample;
using Zenject;

public class GameInstaller : MonoInstaller
{
        public override void InstallBindings()
        {
            var stats = new KeyValuePair<string, int>[]
            {
                new KeyValuePair<string,int>("damage",10),
                new KeyValuePair<string,int>("health",10),
                new KeyValuePair<string,int>("speed",10)
            };
            Container.Bind<Inventory>().AsSingle().NonLazy();
            Container.Bind<Character>().AsSingle().WithArguments(stats).NonLazy();
        }
}