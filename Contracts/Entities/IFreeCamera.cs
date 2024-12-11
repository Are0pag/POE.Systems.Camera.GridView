using Cysharp.Threading.Tasks;

namespace Scripts.Systems.Camera.GridView
{
    internal interface IFreeCamera
    {
        // но как тогда быть с реализацией RaiseEvent? Метод же асинхронный
        UniTask ShowMap(ShowMapArgs args);
    }
}