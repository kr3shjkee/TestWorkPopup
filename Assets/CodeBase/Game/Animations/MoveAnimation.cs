using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace CodeBase.Game.Animations
{
    public class MoveAnimation : MonoBehaviour
    {
        [SerializeField] private float _duration;
        [SerializeField] private Transform _transform;

        private TweenerCore<Vector3, Vector3, VectorOptions> _tween;

        public async UniTask DoAnimationAsync(Vector2 position, CancellationToken token)
        {
            _tween = _transform.DOLocalMove(position, _duration);

            await _tween.WithCancellation(token);
        }
    }
}