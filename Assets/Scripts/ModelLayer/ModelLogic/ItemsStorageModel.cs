using LogicModelInterfaceLayer;
using System.Collections.Generic;

namespace ModelLayer.Model
{
    public class ItemsStorageModel : IItemsStorageModel
    {
        public IEnumerable<IItemModel> Items => _items;

        private List<IItemModel> _items = new();

        public void AddItems(IItemModel item)
        {
            _items.Add(item);
        }

        public void RemoveItems(IItemModel item)
        {
            _items.Remove(item);
        }
    }
}