using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Game.Animations
{
    public class FadeAnimation : MonoBehaviour
    {
        [SerializeField] private float _duration;
        [SerializeField] private Image _image;

        private TweenerCore<Color, Color, ColorOptions> _tween;

        public async UniTask DoAnimationAsync(float fadeValue, CancellationToken token)
        {
            _tween = _image.DOFade(fadeValue, _duration);

            await _tween.WithCancellation(token);
        }
    }
}