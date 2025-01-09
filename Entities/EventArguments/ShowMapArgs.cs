using System.Collections.Generic;
using Scripts.Services.EventBus;
using UnityEngine;

namespace Scripts.Systems.Camera.GridView
{
    public class ShowMapArgs : Args
    {
        internal protected Queue<Vector3> MovePointsTrace { get; }
        internal protected Vector3 StartPosition { get; set; }

        public ShowMapArgs(List<Vector3> movePointsTrace) {
            MovePointsTrace = new Queue<Vector3>(movePointsTrace);
            GetStartPosition();
        }

        protected virtual void GetStartPosition() => StartPosition = MovePointsTrace.Peek();
    }
}