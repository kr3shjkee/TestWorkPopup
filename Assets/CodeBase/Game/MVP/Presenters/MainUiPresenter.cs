using System;
using CodeBase.Core.MVP.Presenters;
using CodeBase.Core.WindowsFSM;
using CodeBase.Game.MVP.Views;
using CodeBase.Game.Windows;
using UnityEngine;

namespace CodeBase.Game.MVP.Presenters
{
    public class MainUiPresenter : IPresenter
    {
        private readonly MainUiView _view;
        private readonly IWindowFsm _windowFsm;

        private readonly Type _window = typeof(MainUi);

        public MainUiPresenter(MainUiView view, IWindowFsm windowFsm)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _windowFsm = windowFsm ?? throw new ArgumentNullException(nameof(windowFsm));
        }
        
        public void Enable()
        {
            _windowFsm.Opened += OnHandleOpenWindow;
            _windowFsm.Closed += OnHandleCloseWindow;
            
            _view.LevelUpButton.onClick.AddListener(LevelUpButtonHandler);
        }

        public void Disable()
        {
            _windowFsm.Opened -= OnHandleOpenWindow;
            _windowFsm.Closed -= OnHandleCloseWindow;
            
            _view.LevelUpButton.onClick.RemoveListener(LevelUpButtonHandler);
        }
        
        private void OnHandleOpenWindow(Type window)
        {
            if(_window != window || _view == null) return;
            
            _view.Show();
        }

        private void OnHandleCloseWindow(Type window)
        {
            if(_window != window || _view == null) return;
            
            _view.Hide();
        }

        private void LevelUpButtonHandler()
        {
            _windowFsm.OpenWindow(typeof(LevelUp), false);
            Debug.Log("Clicked");
        }
    }
}