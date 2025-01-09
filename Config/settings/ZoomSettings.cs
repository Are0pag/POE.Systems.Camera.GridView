using UnityEngine;

namespace Scripts.Systems.Camera.GridView
{
    [System.Serializable]
    internal class ZoomSettings
    {
        /// <summary>
        /// How long will it take to complete the approximation? The lower the value, the faster the operation.
        /// </summary>
        [field: SerializeField, Range(.1f, 10f), Tooltip("How long will it take to complete the approximation? The lower the value, the faster the operation.")] 
        internal protected float ZoomSpeed { get; protected set; }
        
        /// <summary>
        /// Zoom amount per one operation. Expressed in the orthographic size of the camera
        /// </summary>
        [field: SerializeField, Range(.5f, 5f), Tooltip("Zoom amount per one operation. Expressed in the orthographic size of the camera")] 
        internal protected float ZoomAmount { get; protected set; }
        
        /// <summary>
        /// Expressed in the orthographic size of the camera
        /// </summary>
        [field: SerializeField, Range(1f, 3f), Tooltip("Expressed in the orthographic size of the camera")]
        internal protected float MinZoom { get; protected set; }
        
        /// <summary>
        /// Expressed in the orthographic size of the camera
        /// </summary>
        [field: SerializeField, Range(8f, 13f), Tooltip("Expressed in the orthographic size of the camera")]
        internal protected float MaxZoom { get; protected set; }
    }
}