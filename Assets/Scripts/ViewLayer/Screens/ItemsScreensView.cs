using ViewModelLayer.Screens;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using UniRx.Diagnostics;

namespace ViewLayer.Screens
{
    public class ItemsScreensView : AbstratcBindableScreen<ItemsScreenViewModel>
    {
        [SerializeField] Button _openTestScreenButton;

        private readonly CompositeDisposable _disposables = new();

        public override void Bind(ItemsScreenViewModel model)
        {
            _openTestScreenButton
                .onClick
                .AsObservable()
                .Subscribe(_ => model.OnOpenTestScreen())
                .AddTo(_disposables);
        }

        public override void Unbind()
        {
            _disposables.Clear();
        }


    }
}