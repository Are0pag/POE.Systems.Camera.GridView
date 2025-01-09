using System.Diagnostics.CodeAnalysis;
using Cysharp.Threading.Tasks;

namespace Scripts.Systems.Camera.GridView
{
    internal interface IFocusCatcher
    {
        UniTask MoveAt([DisallowNull] MoveToSelectedItemArgs args);
    }
}