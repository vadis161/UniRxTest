
using UnityEngine.UIElements;
using ViewModelLayer.Screens;

namespace ViewLayer.Screens
{
    public interface IBindable<TViewModel> where TViewModel : IViewModel
    {
        void Bind(TViewModel model);
        void Unbind();
    }
}