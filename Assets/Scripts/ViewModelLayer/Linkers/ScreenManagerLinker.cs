using ViewModelLayer.Screens;
using UnityEngine;
using ViewLayer.Screens;
using Zenject;

public class ScreenManagerLinker : IInitializable
{


    private readonly ViewModelLayer.Screens.ScreenManagerViewModel _screenManagerViewModel;

    public ScreenManagerLinker(ViewModelLayer.Screens.ScreenManagerViewModel screenManagerViewModel)
    {
        _screenManagerViewModel = screenManagerViewModel;
    }

    public void Initialize()
    {
        var screenManager = GameObject.Find("ScreenManager").GetComponent<IScreenManager>();
        screenManager.Bind(_screenManagerViewModel);
    }
}
