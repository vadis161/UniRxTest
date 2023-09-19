using LogicModelInterfaceLayer;
using System;
using System.Linq;

namespace LogicLayer
{
    public class ItemsController : IItemsController
    {
        private readonly IItemsStorageModel _itemsStorageModel;
        private readonly IItemModelBuilder _itemBuilder;
        private readonly Random _random;
        public ItemsController(IItemsStorageModel itemsStorageModel, IItemModelBuilder itemBuilder = null)
        {
            _random = new Random();
            _itemsStorageModel = itemsStorageModel;
            _itemBuilder = itemBuilder;
        }

        public void AddRandomItem()
        {
            var typeIndex = _random.Next(0, 5);
            bool needAddModel = true;
            foreach (var item in _itemsStorageModel.Items)
            {
                if (item.TypeIndex == typeIndex)
                {
                    needAddModel = false;
                    item.Count++;
                    break;
                }
            }
            if (needAddModel)
            {
                var item = _itemBuilder.Build(typeIndex);
                item.Count = 1;
                _itemsStorageModel.AddItems(item);
            }
        }

        public void RemoveRandomItem()
        {
            var item = _itemsStorageModel.Items.FirstOrDefault();
            if (item != null)
            {
                item.Count--;
                if (item.Count <= 0)
                {
                    _itemsStorageModel.RemoveItems(item);
                }
            }
        }
    }
}