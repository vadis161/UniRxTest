using DisplayedModelInterfaceLayer;
using LogicModelInterfaceLayer;
using UniRx;

namespace ModelLayer.Model
{
    public class ItemsModel : IItemModel, IItemDisplayedModel
    {
        public int TypeIndex { get; }

        public int Count { get => _bindableCount.Value; set => _bindableCount.Value = value; }
        public IReadOnlyReactiveProperty<int> BindableCount => _bindableCount;

        private ReactiveProperty<int> _bindableCount;
        public ItemsModel(int typeIndex)
        {
            _bindableCount = new ReactiveProperty<int>();
            TypeIndex = typeIndex;
        }
    }
}