
using UnityEngine;
#if UNITY_EDITOR
using Scripts.Tools.CustomEdit;
#endif

namespace Scripts.Systems.Camera.LocationView.View
{

#if UNITY_EDITOR
    [CreateAssetMenu(
        fileName = "View Settings", 
        menuName = DirectoryNames.GRID_VIEW_SETTINGS_PATH + "View Settings")]
#endif
    
    public class ViewSettings : ScriptableObject
    {
        [field: SerializeField] internal protected CameraModeButtonStyle SwapButtonStyle { get; protected set; }
        [field: SerializeField] internal protected CameraModeButtonStyle FocusButtonStyle { get; protected set; }
    }
    
    [System.Serializable]
    public class CameraModeButtonStyle : Scripts.Tools.View.ViewItemStyle { }
}