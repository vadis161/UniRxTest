using Zenject;

namespace ViewModelLayer.Screens
{
    public class ScreenController : IInitializable
    {
        private readonly ScreenManagerViewModel _screenManagerViewModel;
        private readonly ScreenViewModelFactory _screenViewModelFactory;
        public ScreenController(ScreenManagerViewModel screenManagerViewModel, ScreenViewModelFactory screenViewModelFactory)
        {
            _screenManagerViewModel = screenManagerViewModel;
            _screenViewModelFactory = screenViewModelFactory;
        }

        public void Initialize()
        {
            ShowTestScreen();
        }

        public void ShowTestScreen()
        {
            _screenManagerViewModel.ShoweScreen(_screenViewModelFactory.BuildTestViewModel());
        }
        public void ShowItemScreen()
        {
            _screenManagerViewModel.ShoweScreen(_screenViewModelFactory.BuildItemsViewModel());
        }
    }
}