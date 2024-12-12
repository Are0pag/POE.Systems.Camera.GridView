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
        [field: SerializeField] internal protected ZoomSettings ZoomSettings { get; protected set; }
        [field: SerializeField] internal protected FocusSettings FocusSettings { get; protected set; }
    }
}