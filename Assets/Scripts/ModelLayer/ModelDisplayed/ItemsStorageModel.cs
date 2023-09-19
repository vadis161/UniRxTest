using DisplayedModelInterfaceLayer;
using LogicModelInterfaceLayer;
using System.Collections.Generic;
using System.Linq;
using UniRx;

namespace ModelLayer.Model
{
    public class ItemsStorageModel : IItemsStorageModel, IItemsStorageDisplayedModel
    {
        public IEnumerable<IItemModel> Items => _items.Cast<IItemModel>();

        public IReadOnlyReactiveCollection<IItemDisplayedModel> BindableItems => _items;

        private ReactiveCollection<IItemDisplayedModel> _items = new();

        public void AddItems(IItemModel item)
        {
            var itemDisplayedModel = (IItemDisplayedModel)item;
            _items.Add(itemDisplayedModel);
        }

        public void RemoveItems(IItemModel item)
        {
            var itemDisplayedModel = (IItemDisplayedModel)item;
            _items.Remove(itemDisplayedModel);
        }
    }
}