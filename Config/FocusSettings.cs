using UnityEngine;

namespace Scripts.Systems.Camera.GridView
{
    [System.Serializable]
    internal class FocusSettings
    {
        /// <summary>
        /// Speed at which the camera will approach the selected object
        /// </summary>
        [field: Tooltip("Speed at which the camera will approach the selected object")]
        [field: SerializeField] internal protected float CatchSpeed { get; protected set; }
        [field: SerializeField] internal protected float FollowSpeed { get; protected set; }
    }
}