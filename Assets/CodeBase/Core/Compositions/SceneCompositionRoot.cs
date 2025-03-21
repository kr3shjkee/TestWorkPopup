using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace CodeBase.Core.Compositions
{
    public abstract class SceneCompositionRoot : MonoBehaviour
    {
        public abstract UniTask Initialize(DiContainer diContainer);
    }
}