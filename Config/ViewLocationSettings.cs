using UnityEngine;

namespace Scripts.Systems.Camera.GridView
{
    [System.Serializable]
    internal class ViewLocationSettings
    {
        [field: SerializeField] internal protected float TimeOfView  { get; protected set; }
        [field: SerializeField] internal protected float TimeReturn  { get; protected set; }
    }
}