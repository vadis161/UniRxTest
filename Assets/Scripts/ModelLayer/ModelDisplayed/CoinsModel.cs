using DisplayedModelInterfaceLayer;
using LogicModelInterfaceLayer;
using System;
using UniRx;

namespace ModelLayer.Model
{
    public class CoinsModel : ICoinsModel, ICoinsDislapayedMode, IDisposable
    {
        public int GoldCoins { get => _goldConis.Value; set => _goldConis.Value = value; }
        public int SilverCoins { get => _silverConis.Value; set => _silverConis.Value = value; }

        public IReadOnlyReactiveProperty<int> BindableGoldConis => _goldConis;

        public IReadOnlyReactiveProperty<int> BindableSilverConis => _silverConis;

        private ReactiveProperty<int> _goldConis = new();
        private ReactiveProperty<int> _silverConis = new();

        public void Dispose()
        {
            _goldConis.Dispose();
            _silverConis.Dispose();
        }
    }
}