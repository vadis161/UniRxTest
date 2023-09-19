using System.Collections.Generic;

namespace LogicModelInterfaceLayer
{
    public interface IItemsStorageModel
    {
        IEnumerable<IItemModel> Items { get; } 
        public void AddItems(IItemModel item);
        public void RemoveItems(IItemModel item);
    }
}