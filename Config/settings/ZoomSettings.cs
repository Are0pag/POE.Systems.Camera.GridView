using UnityEngine;

namespace Scripts.Systems.Camera.GridView
{
    [System.Serializable]
    internal class ZoomSettings
    {
        [field: SerializeField] internal protected float ZoomSpeed { get; protected set; }
        [field: SerializeField] internal protected float ZoomAmount { get; protected set; }
    }
}