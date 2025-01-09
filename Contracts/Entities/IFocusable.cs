using System.Diagnostics.CodeAnalysis;

namespace Scripts.Systems.Camera.GridView
{
    internal interface IFocusable
    {
        void Follow([DisallowNull] UnityEngine.Transform target);
    }
}