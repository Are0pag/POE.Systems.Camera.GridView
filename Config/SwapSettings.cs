using UnityEngine;

namespace Scripts.Systems.Camera.GridView
{
    [System.Serializable]
    internal class SwapSettings
    {
        [field: SerializeField, Range(0, .1f)] 
        internal protected float SensitivityX { get; protected set; }
        
        [field: SerializeField, Range(0, .1f)] 
        internal protected float SensitivityY { get; protected set; }
    }
}