using UniRx;

namespace DisplayedModelInterfaceLayer
{
    public interface IItemsStorageDisplayedModel
    {
        IReadOnlyReactiveCollection<IItemDisplayedModel> BindableItems { get; }
    }
}