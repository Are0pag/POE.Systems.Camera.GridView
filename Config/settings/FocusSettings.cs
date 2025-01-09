using UnityEngine;

namespace Scripts.Systems.Camera.LocationView
{
    [System.Serializable]
    internal class FocusSettings
    {
        /// <summary>
        /// Speed at which the camera will approach the selected object
        /// </summary>
        [field: SerializeField, Tooltip("Speed at which the camera will approach the selected object")] 
        internal protected float CatchSpeed { get; protected set; }
        
        [field: SerializeField] 
        internal protected float FollowSpeed { get; protected set; }
    }
}