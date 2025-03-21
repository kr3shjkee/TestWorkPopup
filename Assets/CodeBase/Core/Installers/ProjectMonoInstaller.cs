using CodeBase.Core.Compositions;
using CodeBase.Core.WindowsFSM;
using CodeBase.Game;
using CodeBase.Game.Data;
using UnityEngine;
using Zenject;

namespace CodeBase.Core.Installers
{
    public class ProjectMonoInstaller : MonoInstaller
    {
        [SerializeField] private GameSettings _gameSettings;
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<WindowFsm>()
                .AsSingle();
            
            Container
                .BindInstance(_gameSettings);

            Container
                .BindInterfacesAndSelfTo<SceneInitializer>()
                .AsSingle();
            
            Container
                .BindInterfacesAndSelfTo<GameManager>()
                .AsSingle();
        }
    }
}