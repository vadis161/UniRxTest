using UniRx;

namespace ViewModelLayer.Screens
{
    public class ScreenManagerViewModel : IViewModel
    {
        public IReadOnlyReactiveProperty<IViewModel> CurrentScreen => _currentScreen;

        private readonly ReactiveProperty<IViewModel> _currentScreen;
        public ScreenManagerViewModel()
        {
            _currentScreen = new();
        }

        public void ShoweScreen<T>(T viewModel) where T : IViewModel
        {
            if (_currentScreen.Value != null)
                _currentScreen.Value.Dispose();
            _currentScreen.Value = viewModel;
        }

        public void Dispose()
        {
            _currentScreen.Dispose();
        }
    }
}