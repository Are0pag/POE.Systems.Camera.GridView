using Scripts.Tools.AsyncOperationsHandle;

namespace Scripts.Systems.Camera.GridView
{
    internal interface IZoomHandler : IExternalGridViewEventHandler
    {
        void ZoomIn(IAsyncOperationHandlerInitialized asyncOperationHandler);
        void ZoomOut(IAsyncOperationHandlerInitialized asyncOperationHandler);
    }
}