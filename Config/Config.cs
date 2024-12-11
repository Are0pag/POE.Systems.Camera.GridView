using UnityEngine;

#if UNITY_EDITOR
using Scripts.Tools.CustomEdit;
#endif

namespace Scripts.Systems.Camera.GridView
{
    
#if UNITY_EDITOR
    [CreateAssetMenu(
        fileName = nameof(Config), 
        menuName = DirectoryNames.GRID_VIEW_SETTINGS_PATH + nameof(Config))]
#endif
    
    internal class Config : ScriptableObject
    {
        //[field: SerializeField] internal protected bool IsSwapAllowsOnEnable { get; protected set; }
        [field: SerializeField] internal protected ZoomSettings ZoomSettings { get; protected set; }
        [field: SerializeField] internal protected FocusSettings FocusSettings { get; protected set; }

    }

    internal class FocusSettings
    {
        /// <summary>
        /// Speed at which the camera will approach the selected object
        /// </summary>
        [field: Tooltip("Speed at which the camera will approach the selected object")]
        [field: SerializeField] internal protected float CatchSpeed { get; protected set; }
        [field: SerializeField] internal protected float FollowSpeed { get; protected set; }
    }
    
    internal class ZoomSettings
    {
        [field: SerializeField] internal protected float ZoomSpeed { get; protected set; }
        [field: SerializeField] internal protected float ZoomAmount { get; protected set; }
    }
}