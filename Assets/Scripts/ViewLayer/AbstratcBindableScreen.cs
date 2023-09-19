using UnityEngine;
using ViewModelLayer.Screens;

namespace ViewLayer.Screens
{
    public abstract class AbstractScreen : MonoBehaviour
    {
        public abstract void Bind(IViewModel viewModel);
        public abstract void Unbind();
    }

    public abstract class AbstratcBindableScreen<TViewModel> : AbstractScreen, IBindable<TViewModel>
        where TViewModel : IViewModel
    {
        public override void Bind(IViewModel viewModel)
        {
            Bind((TViewModel)viewModel);
        }

        public abstract void Bind(TViewModel model);
    }
}