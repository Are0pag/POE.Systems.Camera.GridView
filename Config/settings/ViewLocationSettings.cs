using UnityEngine;

namespace Scripts.Systems.Camera.LocationView
{
    [System.Serializable]
    internal class ViewLocationSettings
    {
        /// <summary>
        /// The lower the value, the faster the operation.
        /// </summary>
        [field: SerializeField, Range(.05f, 2f), Tooltip("The lower the value, the faster the operation.")] 
        internal protected float TimeOfMovingOneWayPoint  { get; protected set; }
        
        /// <summary>
        /// The lower the value, the faster the operation.
        /// </summary>
        [field: SerializeField, Range(1f, 5f), Tooltip("The higher the value, the slower the operation.")] 
        internal protected float TimeReturn  { get; protected set; }
    }
}