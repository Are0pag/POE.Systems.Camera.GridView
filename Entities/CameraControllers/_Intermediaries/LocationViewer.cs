using Scripts.Services.EventBus;
using Scripts.Tools.AsyncOperationsHandle;
using Zenject;

namespace Scripts.Systems.Camera.LocationView
{
    internal class LocationViewer : IFreeViewHandler, IInitializable, ILateDisposable
    {
        protected private readonly IFocusCatcher _focusCatcher;
        protected readonly UnityEngine.Camera _camera;
        protected private readonly ViewLocationSettings _settings;

        public LocationViewer(IFocusCatcher focusCatcher, UnityEngine.Camera camera, ViewLocationSettings settings) {
            _focusCatcher = focusCatcher;
            _camera = camera;
            _settings = settings;
        }

        public void Initialize() => EventBus<IExternalLocationViewEventSubscriber>.Subscribe(this);

        public void LateDispose() => EventBus<IExternalLocationViewEventSubscriber>.Unsubscribe(this);

        public void OnViewLocation(ShowMapArgs args, IAsyncOperationHandlerInitialized asyncOperationHandler) {
            asyncOperationHandler.Initialize(new LocationViewAsyncOperation(
                _camera,
                _settings,
                _focusCatcher,
                args));
        }
    }
}