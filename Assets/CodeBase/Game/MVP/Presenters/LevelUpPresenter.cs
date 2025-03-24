using System;
using System.Threading;
using CodeBase.Core.MVP.Presenters;
using CodeBase.Core.WindowsFSM;
using CodeBase.Game.Data;
using CodeBase.Game.MVP.Views;
using CodeBase.Game.Windows;
using Cysharp.Threading.Tasks;
using UnityEngine;
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
        private CancellationTokenSource _cts;
        private Vector2 _defaultPosition;
        private float _defaultAlfa;

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
            _defaultAlfa = _view.FogImage.color.a;
            _defaultPosition = _view.Popup.localPosition;
        }

        public void Disable()
        {
            _windowFsm.Opened -= OnHandleOpenWindow;
            _windowFsm.Closed -= OnHandleCloseWindow;
            
            _view.GetButton.onClick.RemoveListener(ButtonHandler);
            _view.ClaimButton.onClick.RemoveListener(ButtonHandler);
            
            _cts?.Dispose();
            _cts = null;
        }
        
        private async void OnHandleOpenWindow(Type window)
        {
            if(_window != window || _view == null) return;

            InitLevelNumber();
            SetDefault();
            _view.Show();
            await ShowAnimationsAsync();
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

        private void SetDefault()
        {
            _view.FogImage.color = new Color(1f,1f,1f,0f);
            float yValue = Screen.currentResolution.width;
            _view.Popup.localPosition = new Vector3(0f, yValue, 0f);
        }

        private async UniTask ShowAnimationsAsync()
        {
            try
            {
                _cts = new CancellationTokenSource();
                await _view.MoveAnimation.DoAnimationAsync(_defaultPosition, _cts.Token);
                await _view.FadeAnimation.DoAnimationAsync(_defaultAlfa, _cts.Token);
            }
            catch (OperationCanceledException e)
            {
                Debug.Log(e);
                _view.Popup.localPosition = Vector3.zero;
                _view.FogImage.color = new Color(1f, 1f, 1f, 0.5f);
            }
            finally
            {
                _cts?.Dispose();
                _cts = null;
            }
        }
    }
}