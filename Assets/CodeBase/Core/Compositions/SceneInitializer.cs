using System;
using Cysharp.Threading.Tasks;
using Zenject;
using Object = UnityEngine.Object;

namespace CodeBase.Core.Compositions
{
    public class SceneInitializer
    {
        private readonly DiContainer _diContainer;

        public SceneInitializer(DiContainer diContainer)
        {
            _diContainer = diContainer ?? throw new ArgumentNullException(nameof(diContainer));
        }

        public UniTask Initialize()
        {
            SceneCompositionRoot[] compositionRoots = Object.FindObjectsOfType<SceneCompositionRoot>();
        
            if (compositionRoots.Length > 1)
            {
                throw new Exception("Scene has multiple composition roots!");
            }
        
            return compositionRoots[0].Initialize(_diContainer);
        }
    }
}