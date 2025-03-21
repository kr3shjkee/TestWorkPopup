using UnityEngine;

namespace CodeBase.Game.Data
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Settings/Create Game Settings", order = 0)]
    public class GameSettings : ScriptableObject
    {
        [field: SerializeField] public int MinLevelInclusive { get; private set; }
        [field: SerializeField] public int MaxLevelInclusive { get; private set; }
    }
}