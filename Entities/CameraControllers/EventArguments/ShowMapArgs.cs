using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Scripts.Services.EventBus;
using UnityEngine;

namespace Scripts.Systems.Camera.GridView
{
    internal class ShowMapArgs : Args
    {
        internal protected Queue<Vector3> MovePointsTrace { get; }

        internal ShowMapArgs(Queue<Vector3> movePointsTrace) {
            MovePointsTrace = movePointsTrace;
        }

        internal ShowMapArgs(List<Vector3> movePointsTrace) {
            MovePointsTrace = new Queue<Vector3>(movePointsTrace);
        }
    }
}