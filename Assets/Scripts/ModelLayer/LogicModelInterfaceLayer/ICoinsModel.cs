using System.Data;

namespace LogicModelInterfaceLayer
{

    public interface ICoinsModel
    {
        public int GoldCoins { get; set; }
        public int SilverCoins { get; set; }
    }
}