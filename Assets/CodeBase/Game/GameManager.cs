using CodeBase.Core.Compositions;
using CodeBase.Core.WindowsFSM;
using CodeBase.Game.Windows;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;
using Zenject;

namespace CodeBase.Game
{
    public class GameManager : IInitializable
    {
        private readonly SceneInitializer _sceneInitializer;
        private readonly IWindowResolve _windowResolve;
        private readonly IWindowFsm _windowFsm;
        private readonly string _mainScene = "MainScene";

        public GameManager(SceneInitializer sceneInitializer, IWindowResolve windowResolve, IWindowFsm windowFsm)
        {
            _sceneInitializer = sceneInitializer;
            _windowResolve = windowResolve;
            _windowFsm = windowFsm;
        }
        
        public async void Initialize()
        {
            PreparedWindows();
            await SceneManager.LoadSceneAsync(_mainScene);
            await _sceneInitializer.Initialize();
            _windowFsm.OpenWindow(typeof(MainUi), true);
        }
        
        private void PreparedWindows()
        {
            _windowResolve.CleanUp();

            _windowResolve.Set<MainUi>();
            _windowResolve.Set<LevelUp>();
        }
    }
}