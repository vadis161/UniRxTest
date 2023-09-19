using UniRx;

namespace DisplayedModelInterfaceLayer
{
    public interface ICoinsDislapayedMode
    {
        IReadOnlyReactiveProperty<int> BindableGoldConis { get; }
        IReadOnlyReactiveProperty<int> BindableSilverConis { get; }
    }
}