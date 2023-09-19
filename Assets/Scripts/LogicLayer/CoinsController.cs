using LogicModelInterfaceLayer;

namespace LogicLayer
{
    public class CoinsController : ICoinsController
    {
        private readonly ICoinsModel _coinModel;

        public CoinsController(ICoinsModel coinModel)
        {
            _coinModel = coinModel;
        }

        public void IncreaseGoldCoin()
        {
            _coinModel.GoldCoins += 1;
        }

        public void IncreaseSilverCoin()
        {
            _coinModel.SilverCoins += 1;
        }
    }
}