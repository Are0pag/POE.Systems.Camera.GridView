using Scripts.Tools.Attributes;
using UnityEngine;

namespace Scripts.Systems.Camera.GridView
{
    [System.Serializable]
    internal class SceneSettings
    {
        [SerializeField] [FindInScene] private UnityEngine.Camera _camera;
        internal protected UnityEngine.Camera Camera {
            get => _camera;
            protected set => _camera = value;
        }
    }
}