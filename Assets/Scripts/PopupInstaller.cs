using Models;
using Presenters;
using UnityEngine;
using Views;
using Zenject;

public class PopupInstaller : MonoInstaller
{
    [SerializeField] private CharacterPopupView characterPopupView;
    [SerializeField] private TavernView tavernView;
    [SerializeField] private CharacterData[] characters;

    public override void InstallBindings()
    {
        Container.Bind<TavernCharacterService>().AsSingle().WithArguments(characters).NonLazy();
        Container.Bind<CharacterPopupPresenter>().AsSingle().WithArguments(characterPopupView).NonLazy();
        Container.Bind<TavernPresenter>().AsSingle().WithArguments(tavernView).NonLazy();
    }
}