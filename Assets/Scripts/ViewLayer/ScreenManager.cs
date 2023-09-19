using ViewModelLayer.Screens;
using UnityEngine;
using UniRx;
using System.Collections.Generic;
using System;
using UnityEngine.Device;
using System.Linq;

namespace ViewLayer.Screens
{
    public class ScreenManager : MonoBehaviour, IScreenManager
    {
        [SerializeField] private GameObject[] _screens;

        private readonly Dictionary<Type, AbstractScreen> _allScreen = new();

        private AbstractScreen _currentScreen;
        public void Bind(ViewModelLayer.Screens.ScreenManagerViewModel model)
        {
            model.CurrentScreen.Subscribe(OnCurrentScreenChange);
        }
        public void Unbind()
        {

        }

        private void Awake()
        {
            InitializeScreen();
        }

        private void InitializeScreen()
        {
            foreach (var screen in _screens)
            {
                var goScreen = Instantiate(screen, transform);
                goScreen.SetActive(false);
                var screenView = goScreen.GetComponent<AbstractScreen>();
                var viewModelType = screenView
                                        .GetType()
                                        .BaseType
                                        .GetGenericArguments()
                                        .Single();
                _allScreen.Add(viewModelType, screenView);
            }
        }

        private void OnCurrentScreenChange(IViewModel viewModel)
        {
            if (viewModel == null)
                return;
            if (_currentScreen)
            {
                _currentScreen.Unbind();
                _currentScreen.gameObject.SetActive(false);
            }
            _currentScreen = _allScreen[viewModel.GetType()];
            _currentScreen.Bind(viewModel);
            _currentScreen.gameObject.SetActive(true);
        }


    }
}
