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
            AdaptMoveTrace(movePointsTrace);
            MovePointsTrace = new Queue<Vector3>(movePointsTrace);
            GetStartPosition();
        }

        protected virtual void GetStartPosition() {
            StartPosition = MovePointsTrace.Peek();
        }

        protected virtual void AdaptMoveTrace(List<Vector3> movePointsTrace) {
            for (int i = 0; i < movePointsTrace.Count; i++) {
                if (i % 2 == 0) 
                    movePointsTrace.RemoveAt(i);
            }
        }
    }
}