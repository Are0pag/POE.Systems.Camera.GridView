using Scripts.Tools.AsyncOperationsHandle;

namespace Scripts.Systems.Camera.GridView
{
    public interface IZoomHandler : IExternalGridViewEventHandler
    {
        void ZoomIn(IAsyncOperationHandlerInitialized asyncOperationHandler);
        void ZoomOut(IAsyncOperationHandlerInitialized asyncOperationHandler);
    }
}