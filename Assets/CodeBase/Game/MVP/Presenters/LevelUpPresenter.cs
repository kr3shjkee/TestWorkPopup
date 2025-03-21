using System;
using CodeBase.Core.MVP.Presenters;
using CodeBase.Core.WindowsFSM;
using CodeBase.Game.MVP.Views;
using CodeBase.Game.Windows;

namespace CodeBase.Game.MVP.Presenters
{
    public class LevelUpPresenter : IPresenter
    {
        private readonly LevelUpView _view;
        private readonly IWindowFsm _windowFsm;

        private readonly Type _window = typeof(LevelUp);

        public LevelUpPresenter(LevelUpView view, IWindowFsm windowFsm)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _windowFsm = windowFsm ?? throw new ArgumentNullException(nameof(windowFsm));
        }
        
        public void Enable()
        {
            _windowFsm.Opened += OnHandleOpenWindow;
            _windowFsm.Closed += OnHandleCloseWindow;
        }

        public void Disable()
        {
            _windowFsm.Opened -= OnHandleOpenWindow;
            _windowFsm.Closed -= OnHandleCloseWindow;
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
    }
}