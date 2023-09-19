using LogicModelInterfaceLayer;

namespace ModelLayer.Model
{
    public class ItemsModel : IItemModel
    {
        public int TypeIndex { get; }
        public int Count { get; set; }
        public int BindableCount { get; set; }

    }
}