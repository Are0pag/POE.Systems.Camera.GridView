using Scripts.Tools.AsyncOperationsHandle;

namespace Scripts.Systems.Camera.GridView
{
    public interface IFreeViewHandler : IExternalGridViewEventHandler
    {
        void OnViewLocation(ShowMapArgs args, IAsyncOperationHandlerInitialized asyncOperationHandler);
    }
}