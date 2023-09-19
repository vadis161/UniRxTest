using UniRx;

namespace DisplayedModelInterfaceLayer
{
    public interface IItemDisplayedModel
    {
        public int TypeIndex { get; }
        public IReadOnlyReactiveProperty<int> BindableCount { get; }
    }
}