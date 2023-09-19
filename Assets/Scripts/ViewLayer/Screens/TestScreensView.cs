using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using ViewModelLayer.Elements;
using ViewModelLayer.Screens;

namespace ViewLayer.Screens
{

    public class TestScreensView : AbstratcBindableScreen<TestScreenViewModel>
    {
        [SerializeField] TextMeshProUGUI _goldCoinLabel;
        [SerializeField] TextMeshProUGUI _silverCoinLabel;
        [SerializeField] TextMeshProUGUI _allCoinLabel;

        [SerializeField] Button _increaseGoldCoinButton;
        [SerializeField] Button _increaseSilverCoinButton;
        [SerializeField] Button _openItemScreenButton;

        [SerializeField] ItemListView _itemListView;

        private readonly CompositeDisposable _disposables = new();

        public override void Bind(TestScreenViewModel model)
        {
            _itemListView.Bind(model.ItemListViewModel);

            _openItemScreenButton
                .onClick
                .AsObservable()
                .Subscribe(_ => model.OnOpenItemsScreen())
                .AddTo(_disposables);

            _increaseGoldCoinButton
                .onClick
                .AsObservable()
                .Subscribe(_ => model.OnAddGoldCoint())
                .AddTo(_disposables);

            _increaseSilverCoinButton
                .onClick
                .AsObservable()
                .Subscribe(_ => model.OnAddSilverCoint())
                .AddTo(_disposables);

            model.GoldCoin
                .Subscribe(c => _goldCoinLabel.text = $"Gold coin count: {c}")
                .AddTo(_disposables);

            model.SilverCoin
                .Subscribe(c => _silverCoinLabel.text = $"Silver coin count: {c}")
                .AddTo(_disposables);

            model.AllCoin
                .Subscribe(c => _allCoinLabel.text = $"All coin count: {c}")
                .AddTo(_disposables);
        }

        public override void Unbind()
        {
            _itemListView.Unbind();
            _disposables.Clear();
        }
    }
}