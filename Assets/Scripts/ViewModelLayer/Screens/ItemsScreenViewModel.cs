using UniRx;

namespace ViewModelLayer.Screens
{
    public class ItemsScreenViewModel : IViewModel
    {
        public IReadOnlyReactiveProperty<int> CoinCount;

        private readonly ScreenController _screenController;

        public ItemsScreenViewModel(ScreenController screenController)
        {
            _screenController = screenController;
        }

        public void OnOpenTestScreen()
        {
            _screenController.ShowTestScreen();
        }

        public void Dispose()
        {
            
        }
    }
}