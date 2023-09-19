using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using ViewLayer.Screens;
using ViewModelLayer.Elements;

public class ItemListView : MonoBehaviour, IBindable<ItemListViewModel>
{
    [SerializeField] ItemsView _itemsView;
    [SerializeField] Transform _container;
    [SerializeField] Button _addButton;
    [SerializeField] Button _removeButton;

    private List<ItemsView> _itemsViews = new List<ItemsView>();

    private readonly CompositeDisposable _disposables = new();
    public void Bind(ItemListViewModel model)
    {
        var d = _addButton
            .onClick
            .AsObservable()
            .Subscribe(_ => model.OnAddElement())
            .AddTo(_disposables);

        _removeButton
            .onClick
            .AsObservable()
            .Subscribe(_ => model.OnRemoveElement())
            .AddTo(_disposables);


        foreach (var viewModel in model.ItemModels)
        {
            InstantiateView(viewModel);
        }

        _disposables.Add(model.ItemModels
            .ObserveRemove()
            .Subscribe(OnRemoveItem));
        _disposables.Add(model.ItemModels
             .ObserveAdd()
             .Subscribe(OnAddItem));
    }

    private void OnAddItem(CollectionAddEvent<ItemViewModel> model)
    {
        throw new System.Exception("1");
        InstantiateView(model.Value);

    }
    private void OnRemoveItem(CollectionRemoveEvent<ItemViewModel> model)
    {
        ItemsView toRemove = null;
        foreach (var view in _itemsViews)
        {
            if (view.IsBindedToModel(model.Value))
            {
                toRemove = view;
                break;
            }
        }
        if (toRemove != null)
        {
            _itemsViews.Remove(toRemove);
            toRemove.Unbind();
            Destroy(toRemove.gameObject);
        }
    }

    private void InstantiateView(ItemViewModel model)
    {
        var view = Instantiate(_itemsView, _container);
        view.Bind(model);
        _itemsViews.Add(view);
    }

    public void Unbind()
    {
        _disposables.Clear();
    }
}
