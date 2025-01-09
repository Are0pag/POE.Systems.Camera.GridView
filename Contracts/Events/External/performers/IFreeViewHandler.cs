using Scripts.Tools.AsyncOperationsHandle;

namespace Scripts.Systems.Camera.LocationView
{
    public interface IFreeViewHandler : IExternalLocationViewEventSubscriber
    {
        void OnViewLocation(ShowMapArgs args, IAsyncOperationHandlerInitialized asyncOperationHandler);
    }
}