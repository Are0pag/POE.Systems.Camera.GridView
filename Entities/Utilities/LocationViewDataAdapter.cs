using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Systems.Camera.LocationView
{
    public class LocationViewDataAdapter
    {
        internal protected LocationViewDataAdapter() { }
        
        public virtual List<Vector3> AdaptMoveTrace(List<Vector3> movePointsTrace) {
            var adaptMovePointsTrace = new List<Vector3>();
            for (int i = 0; i < movePointsTrace.Count; i++) {
                if (i % 2 != 0) 
                    adaptMovePointsTrace.Add(movePointsTrace[i]);
            }
            return adaptMovePointsTrace;
        }
    }
}