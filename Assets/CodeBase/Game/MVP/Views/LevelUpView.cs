using CodeBase.Core.MVP.Views;
using CodeBase.Game.Animations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

namespace CodeBase.Game.MVP.Views
{
    public class LevelUpView : CanvasGroupView
    {
        [field: SerializeField] public Button GetButton { get; private set; }
        [field: SerializeField] public Button ClaimButton { get; private set; }
        [field: SerializeField] public TMP_Text LevelNumberText { get; private set; }
        [field: SerializeField] public Transform Popup { get; private set; }
        [field: SerializeField] public MoveAnimation MoveAnimation { get; private set; }
        [field: SerializeField] public Image FogImage { get; private set; }
        [field: SerializeField] public FadeAnimation FadeAnimation { get; private set; }
        [field: SerializeField] public UIParticleSystem StarsParticle { get; private set; }
        [field: SerializeField] public UIParticleSystem RaysParticle { get; private set; }
    }
}