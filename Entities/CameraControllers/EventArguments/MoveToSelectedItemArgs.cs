using Scripts.Services.EventBus;
using UnityEngine;

namespace Scripts.Systems.Camera.GridView
{
    internal class MoveToSelectedItemArgs : Args
    {
        internal Transform Target;
    }
}