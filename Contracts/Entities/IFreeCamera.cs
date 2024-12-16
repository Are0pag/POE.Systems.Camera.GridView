using System.Diagnostics.CodeAnalysis;
using Cysharp.Threading.Tasks;

namespace Scripts.Systems.Camera.GridView
{
    internal interface IFreeCamera : ICancelable
    {
        UniTask ShowMapAsyncRecursive([DisallowNull] ShowMapArgs args);
    }
}