using Cysharp.Threading.Tasks;

namespace Scripts.Systems.Camera.GridView
{
    internal interface IZoom
    {
        UniTask ZoomIn();
        
        UniTask ZoomOut();
    }
}