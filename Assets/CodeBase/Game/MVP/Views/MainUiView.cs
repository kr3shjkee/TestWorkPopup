using CodeBase.Core.MVP.Views;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Game.MVP.Views
{
    public class MainUiView : CanvasGroupView
    {
        [field: SerializeField] public Button LevelUpButton { get; private set; }
    }
}