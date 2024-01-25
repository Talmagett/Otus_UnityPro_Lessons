using Models;
using UI;
using UnityEngine;
using Zenject;

public class PopupInstaller : MonoInstaller
{
    [SerializeField] private CharacterPopup characterPopup;
    [SerializeField] private TavernPopup tavernPopup;
    [SerializeField] private CharacterData[] characters;

    public override void InstallBindings()
    {
        Container.BindInstance(characterPopup).AsSingle();
        Container.BindInstance(tavernPopup).AsSingle();
        Container.Bind<TavernCharacterService>().AsSingle().WithArguments(characters).NonLazy();
    }
}