using ModelLayer.Model;
using ViewModelLayer.Elements;
using Zenject;

public class ModelInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<CoinsModel>().AsSingle();
        Container.BindInterfacesAndSelfTo<ItemsStorageModel>().AsSingle();
        Container.BindInterfacesAndSelfTo<ItemModelBuilder>().AsSingle();
        Container.BindInterfacesAndSelfTo<ItemListViewModel>().AsSingle();
    }
}