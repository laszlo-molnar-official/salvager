using Globals.GameEvents;
using UnityEngine;

namespace Assets.Scripts.Events
{
    [CreateAssetMenu(menuName = "Game Events/Event With Bool")]
    public class GameEvent_Bool : GameEvent<bool>
    {
    }
}
