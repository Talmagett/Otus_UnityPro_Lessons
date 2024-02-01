using SaveSystem;
using UnityEngine;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
  [SerializeReference] private ISaveLoader[] saveLoaders;
  
  public override void InstallBindings()
  {
    Container.Bind<GameRepository>().AsSingle().NonLazy();
    Container.BindInstance(saveLoaders).AsSingle();
  }
}