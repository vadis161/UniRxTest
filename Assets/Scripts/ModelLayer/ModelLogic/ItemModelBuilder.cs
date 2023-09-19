using LogicModelInterfaceLayer;

namespace ModelLayer.Model
{
    public class ItemModelBuilder : IItemModelBuilder
    {
        public IItemModel Build(int typeIndex)
        {
            return new ItemsModel(typeIndex);
        }
    }
}