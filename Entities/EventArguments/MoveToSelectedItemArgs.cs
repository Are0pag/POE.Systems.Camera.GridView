using System.Diagnostics.CodeAnalysis;
using Scripts.Services.EventBus;
using UnityEngine;

namespace Scripts.Systems.Camera.LocationView
{
    internal class MoveToSelectedItemArgs : Args
    {
        internal protected Vector3 Target { get; }

        internal MoveToSelectedItemArgs([DisallowNull] Vector3 target) {
            Target = target;
        }
    }
}