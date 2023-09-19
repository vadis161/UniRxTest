using LogicLayer;
using Zenject;

public class LogicLayerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<CoinsController>().AsSingle();
        Container.BindInterfacesAndSelfTo<ItemsController>().AsSingle();
    }
}