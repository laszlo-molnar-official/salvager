using Assets._Salvager.Scripts.Level;
using Globals.GameEvents;
using UnityEngine;

namespace Assets.Scripts.Events
{
    [CreateAssetMenu(menuName = "Game Events/Event With LevelSummary")]
    public class GameEvent_LevelSummary : GameEvent<LevelSummary>
    {
    }
}
