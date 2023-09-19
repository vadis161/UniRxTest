using DisplayedModelInterfaceLayer;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using ViewModelLayer.Screens;

namespace ViewModelLayer.Elements
{
    public class ItemListViewModel : IViewModel
    {
        public IReadOnlyReactiveCollection<ItemViewModel> ItemModels => _items;

        private readonly ReactiveCollection<ItemViewModel> _items;
        private readonly Dictionary<IItemDisplayedModel, ItemViewModel> _modelToViewModel;

        private readonly IItemsStorageDisplayedModel _displayedModel;
        private readonly IItemsController _itemsController;

        private readonly CompositeDisposable _disposables;

        public ItemListViewModel(IItemsStorageDisplayedModel displayedModel, IItemsController itemsController)
        {
            _modelToViewModel = new Dictionary<IItemDisplayedModel, ItemViewModel>();
            _disposables = new CompositeDisposable();

            _displayedModel = displayedModel;
            _itemsController = itemsController;

            var itemsViewModel = _displayedModel.BindableItems.Select(CreateFromModel);
            _items = new ReactiveCollection<ItemViewModel>(itemsViewModel);

            _disposables.Add(_displayedModel.BindableItems
                .ObserveRemove()
                .Subscribe(OnRemoveItem));
            _disposables.Add(_displayedModel.BindableItems
                 .ObserveAdd()
                 .Subscribe(OnAddItem));
        }

        public void OnAddElement()
        {
            _itemsController.AddRandomItem();
        }

        public void OnRemoveElement()
        {
            _itemsController.RemoveRandomItem();
        }

        private void OnAddItem(CollectionAddEvent<IItemDisplayedModel> model)
        {
            _items.Add(CreateFromModel(model.Value));
        }
        private void OnRemoveItem(CollectionRemoveEvent<IItemDisplayedModel> model)
        {
            _items.Remove(_modelToViewModel[model.Value]);
            _modelToViewModel.Remove(model.Value);
        }

        private ItemViewModel CreateFromModel(IItemDisplayedModel model)
        {
            var viewModel = new ItemViewModel(model);
            _modelToViewModel.Add(model, viewModel);
            return viewModel;
        }

        public void Dispose()
        {
            _items.Dispose();
            _disposables.Clear();
        }
    }
}