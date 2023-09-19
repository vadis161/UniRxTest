using Zenject;

namespace ViewModelLayer.Screens
{
    public class ScreenViewModelFactory
    {
        private readonly DiContainer _container;

        public ScreenViewModelFactory(DiContainer container)
        {
            _container = container;
        }

        public IViewModel BuildTestViewModel()
        {
            return _container.Instantiate<TestScreenViewModel>();
        }

        public IViewModel BuildItemsViewModel()
        {
            return _container.Instantiate<ItemsScreenViewModel>();
        }
    }
}