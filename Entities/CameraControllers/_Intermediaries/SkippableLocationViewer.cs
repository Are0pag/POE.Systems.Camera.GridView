using POE.Systems.Camera.LocationView;
using Scripts.Tools.AsyncOperationsHandle;

namespace Scripts.Systems.Camera.LocationView
{
    internal class SkippableLocationViewer : LocationViewer, ISkipFreeViewHandler
    {
        protected SkipLocationViewAsyncOperation _skipLocationViewAsyncOperation;
        
        internal SkippableLocationViewer(IFocusCatcher focusCatcher, UnityEngine.Camera camera, ViewLocationSettings settings) 
            : base(focusCatcher, camera, settings) {
        }

        void ISkipFreeViewHandler.OnSkip(IAsyncOperationHandlerInitialized asyncOperationHandler) {
            asyncOperationHandler.Initialize(_skipLocationViewAsyncOperation);
        }

        public override void OnViewLocation(ShowMapArgs args, IAsyncOperationHandlerInitialized asyncOperationHandler) {
            var locationViewAsyncOperation = CreateAsyncOperation(args);
            asyncOperationHandler.Initialize(locationViewAsyncOperation);
            
            _skipLocationViewAsyncOperation = new SkipLocationViewAsyncOperation(locationViewAsyncOperation);
        }
    }
}