using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace Scripts.Systems.Camera.GridView
{
    internal interface IFocusable
    {
        [AllowNull]
        Transform Target { get; set; }

        //UniTask MoveAt(MoveToSelectedItemArgs args);  -> event
        
        void Follow();
    }
}