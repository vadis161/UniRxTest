using LogicModelInterfaceLayer;

namespace ModelLayer.Model
{
    public class CoinsModel : ICoinsModel
    {
        public int GoldCoins { get; set; }
        public int SilverCoins { get; set; }
    }
}