using Scripts.Tools.AsyncOperationsHandle;

namespace Scripts.Systems.Camera.LocationView
{
    public interface IZoomHandler : IExternalLocationViewEventSubscriber
    {
        void ZoomIn(IAsyncOperationHandlerInitialized asyncOperationHandler);
        void ZoomOut(IAsyncOperationHandlerInitialized asyncOperationHandler);
    }
}