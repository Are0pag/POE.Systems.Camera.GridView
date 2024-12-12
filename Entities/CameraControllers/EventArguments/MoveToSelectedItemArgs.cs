using System.Diagnostics.CodeAnalysis;
using Scripts.Services.EventBus;
using UnityEngine;

namespace Scripts.Systems.Camera.GridView
{
    internal class MoveToSelectedItemArgs : Args
    {
        internal protected Transform Target { get; }

        internal MoveToSelectedItemArgs([DisallowNull] Transform target) {
            Target = target;
        }
    }
}