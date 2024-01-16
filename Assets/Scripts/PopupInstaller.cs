using Models;
using UI;
using UnityEngine;
using Zenject;

public class PopupInstaller:MonoInstaller
{
        public override void InstallBindings()
        {
                Container.Bind<PopupManager>().AsSingle().NonLazy();
        }
}