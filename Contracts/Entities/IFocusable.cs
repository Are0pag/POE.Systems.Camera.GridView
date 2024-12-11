using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Scripts.Systems.Camera.GridView
{
    internal interface IFocusable
    {
        Transform Target { get; }

        UniTask MoveAt(MoveToSelectedItemArgs args);
        
        void Follow();
    }
}