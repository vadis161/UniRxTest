using ViewModelLayer.Screens;
using Zenject;

public class ViewLayerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<ScreenController>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<ScreenManagerLinker>().AsSingle();
        Container.BindInterfacesAndSelfTo<ScreenManagerViewModel>().AsSingle();

        Container.BindInterfacesAndSelfTo<ItemsScreenViewModel>().AsSingle();
        Container.BindInterfacesAndSelfTo<TestScreenViewModel>().AsSingle();

        Container.Bind<ScreenViewModelFactory>().AsSingle();
    }
}
