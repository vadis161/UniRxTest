using System;
using TMPro;
using UniRx;
using UnityEngine;
using ViewLayer.Screens;
using ViewModelLayer.Elements;

public class ItemsView : MonoBehaviour, IBindable<ItemViewModel>
{
    [SerializeField] TextMeshProUGUI TypeLabel;
    [SerializeField] TextMeshProUGUI CountLabel;

    private ItemViewModel _model;
    private readonly CompositeDisposable _disposables = new();
    public void Bind(ItemViewModel model)
    {
        _model = model;

        TypeLabel.text = $"Type index: {model.TypeIndex}";
        model.Count
            .Subscribe(c => CountLabel.text = $"Count: {c}")
            .AddTo(_disposables);
    }

    public bool IsBindedToModel(ItemViewModel model)
    {
        return model == _model;
    }

    public void Unbind()
    {
        _disposables.Clear();
    }
}
