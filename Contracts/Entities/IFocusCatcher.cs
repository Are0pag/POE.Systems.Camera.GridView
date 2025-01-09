using System.Diagnostics.CodeAnalysis;
using Cysharp.Threading.Tasks;

namespace Scripts.Systems.Camera.LocationView
{
    internal interface IFocusCatcher
    {
        UniTask MoveAt([DisallowNull] MoveToSelectedItemArgs args);
    }
}