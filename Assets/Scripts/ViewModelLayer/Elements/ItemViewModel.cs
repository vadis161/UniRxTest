using DisplayedModelInterfaceLayer;
using UniRx;
using ViewModelLayer.Screens;

namespace ViewModelLayer.Elements
{
    public class ItemViewModel : IViewModel
    {
        public int TypeIndex { get; }
        public IReadOnlyReactiveProperty<int> Count => _count;

        private readonly IItemDisplayedModel _itemsModel;

        private readonly ReactiveProperty<int> _count;
        private readonly CompositeDisposable _disposables = new();
        public ItemViewModel(IItemDisplayedModel itemsModel)
        {
            _itemsModel = itemsModel;
            TypeIndex = _itemsModel.TypeIndex;
            _count = new ReactiveProperty<int>();
            _disposables.Add(_itemsModel.BindableCount
                .Subscribe(count => _count.Value = count));
        }

        public void Dispose()
        {
            _disposables.Clear();
        }
    }
}