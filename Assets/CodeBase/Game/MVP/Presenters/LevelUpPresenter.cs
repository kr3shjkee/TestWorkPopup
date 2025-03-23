using System;
using CodeBase.Core.MVP.Presenters;
using CodeBase.Core.WindowsFSM;
using CodeBase.Game.Data;
using CodeBase.Game.MVP.Views;
using CodeBase.Game.Windows;
using Random = UnityEngine.Random;

namespace CodeBase.Game.MVP.Presenters
{
    public class LevelUpPresenter : IPresenter
    {
        private readonly LevelUpView _view;
        private readonly IWindowFsm _windowFsm;
        private readonly GameSettings _gameSettings;

        private readonly Type _window = typeof(LevelUp);

        private int _number;

        public LevelUpPresenter(LevelUpView view, IWindowFsm windowFsm, GameSettings gameSettings)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _windowFsm = windowFsm ?? throw new ArgumentNullException(nameof(windowFsm));
            _gameSettings = gameSettings ?? throw new ArgumentNullException(nameof(gameSettings));
        }
        
        public void Enable()
        {
            _windowFsm.Opened += OnHandleOpenWindow;
            _windowFsm.Closed += OnHandleCloseWindow;
            
            _view.GetButton.onClick.AddListener(ButtonHandler);
            _view.ClaimButton.onClick.AddListener(ButtonHandler);

            _number = Random.Range(_gameSettings.MinLevelInclusive, _gameSettings.MaxLevelInclusive + 1);
        }

        public void Disable()
        {
            _windowFsm.Opened -= OnHandleOpenWindow;
            _windowFsm.Closed -= OnHandleCloseWindow;
            
            _view.GetButton.onClick.RemoveListener(ButtonHandler);
            _view.ClaimButton.onClick.RemoveListener(ButtonHandler);
        }
        
        private void OnHandleOpenWindow(Type window)
        {
            if(_window != window || _view == null) return;

            InitLevelNumber();
            _view.Show();
            EnableParticles();
        }

        private void OnHandleCloseWindow(Type window)
        {
            if(_window != window || _view == null) return;

            DisableParticles();
            _view.Hide();
        }

        private void ButtonHandler()
        {
            _windowFsm.CloseWindow(_window);
        }

        private void EnableParticles()
        {
            _view.RaysParticle.StartParticleEmission();
            _view.StarsParticle.StartParticleEmission();
        }
        
        private void DisableParticles()
        {
            _view.RaysParticle.StopParticleEmission();
            _view.StarsParticle.StopParticleEmission();
        }

        private void InitLevelNumber()
        {
            _number++;
            string levelText = _gameSettings.LevelNumberText;
            string separator = _gameSettings.Separator;
            _view.LevelNumberText.text = levelText.Replace(separator, _number.ToString());
        }
    }
}