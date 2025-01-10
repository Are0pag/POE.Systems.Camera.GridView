using Scripts.Systems.Camera.LocationView;
using Scripts.Tools.AsyncOperationsHandle;

namespace POE.Systems.Camera.LocationView
{
    public interface ISkipFreeViewHandler : IExternalLocationViewEventSubscriber
    {
        void OnSkip(IAsyncOperationHandlerInitialized asyncOperationHandler);
    }
}