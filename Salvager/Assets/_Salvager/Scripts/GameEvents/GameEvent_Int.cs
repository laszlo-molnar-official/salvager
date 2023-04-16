using Globals.GameEvents;
using UnityEngine;

namespace Assets.Scripts.Events
{
    [CreateAssetMenu(menuName = "Game Events/Event With Integer")]
    public class GameEvent_Int : GameEvent<int>
    {
    }
}
