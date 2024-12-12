using Cysharp.Threading.Tasks;

namespace Scripts.Systems.Camera.GridView
{
    internal interface IFreeCamera : ICancelable
    {
        UniTask ShowMap(ShowMapArgs args);
    }
}