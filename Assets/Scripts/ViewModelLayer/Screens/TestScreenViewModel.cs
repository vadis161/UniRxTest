using DisplayedModelInterfaceLayer;
using LogicLayer;
using System;
using UniRx;
using ViewModelLayer.Elements;

namespace ViewModelLayer.Screens
{
    public class TestScreenViewModel : IViewModel, IDisposable
    {
        public IReadOnlyReactiveProperty<int> GoldCoin => _coinsModel.BindableGoldConis;
        public IReadOnlyReactiveProperty<int> SilverCoin => _coinsModel.BindableSilverConis;
        public IReadOnlyReactiveProperty<int> AllCoin => _allCoin;

        public ItemListViewModel ItemListViewModel => _itemListViewModel;

        private readonly ScreenController _screenController;
        private readonly ICoinsDislapayedMode _coinsModel;
        private readonly ICoinsController _coinsController;

        private ReactiveProperty<int> _allCoin;
        private ItemListViewModel _itemListViewModel;


        private readonly CompositeDisposable _disposables;



        public TestScreenViewModel(ICoinsDislapayedMode coinsModel, ICoinsController coinsController, ScreenController screenController, ItemListViewModel itemListViewModel)
        {

            _disposables = new();

            _allCoin = new();

            _coinsController = coinsController;
            _screenController = screenController;
            _itemListViewModel = itemListViewModel;
            _coinsModel = coinsModel;

            var allCoinDispos = _coinsModel.BindableGoldConis
                .CombineLatest(_coinsModel.BindableSilverConis, (gold, silver) => gold + silver)
                .Subscribe(v => _allCoin.Value = v);
            _disposables.Add(allCoinDispos);
        }

        public void OnAddGoldCoint()
        {
            _coinsController.IncreaseGoldCoin();
        }

        public void OnAddSilverCoint()
        {
            _coinsController.IncreaseSilverCoin();
        }

        public void OnOpenItemsScreen()
        {
            _screenController.ShowItemScreen();
        }

        public void Dispose()
        {
            _disposables.Clear();
            _allCoin.Dispose();
        }
    }
}