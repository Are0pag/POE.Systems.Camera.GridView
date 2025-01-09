using System.Diagnostics.CodeAnalysis;

namespace Scripts.Systems.Camera.LocationView
{
    internal interface IFocusable
    {
        void Follow([DisallowNull] UnityEngine.Transform target);
    }
}