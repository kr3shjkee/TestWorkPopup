using CodeBase.Game.MVP.Presenters;
using CodeBase.Game.MVP.Views;
using UnityEngine;
using Zenject;

namespace CodeBase.Game.Installers
{
    public class MainSceneMonoInstaller : MonoInstaller
    {
        [SerializeField] private MainUiView _mainUiView;
        [SerializeField] private LevelUpView _levelUpView;
        public override void InstallBindings()
        {
            BindViews();
            BindPresenters();
        }

        private void BindPresenters()
        {
            Container.BindInterfacesAndSelfTo<MainUiPresenter>().AsTransient();
            Container.BindInterfacesAndSelfTo<LevelUpPresenter>().AsTransient();
        }

        private void BindViews()
        {
            Container.BindInstance(_mainUiView);
            Container.BindInstance(_levelUpView);
        }
    }
}