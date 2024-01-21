using UI;
using Zenject;

public class PopupInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<PopupManager>().AsSingle().NonLazy();
    }
}