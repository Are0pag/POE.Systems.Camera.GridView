using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace Scripts.Systems.Camera.GridView
{
    internal interface IFocusable
    {
        [AllowNull]
        Transform Target { get; set; }
        
        void Follow();
    }
}