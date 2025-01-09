using Scripts.Services.EventBus;
using Scripts.Tools;
using Scripts.Tools.AsyncOperationsHandle;
using Scripts.Tools.Interpolation;
using UnityEngine;
using Zenject;

namespace Scripts.Systems.Camera.GridView
{
    internal class Zoom : IZoomHandler, Zenject.IInitializable, Zenject.ILateDisposable
    {
        protected readonly UnityEngine.Camera _camera;
        protected readonly ZoomSettings _settings;

        public Zoom(UnityEngine.Camera camera, Config config) {
            _camera = camera;
            _settings = config.ZoomSettings;
        }

        void IInitializable.Initialize() => EventBus<IExternalGridViewEventHandler>.Subscribe(this);

        void ILateDisposable.LateDispose() => EventBus<IExternalGridViewEventHandler>.Unsubscribe(this);

        void IZoomHandler.ZoomIn(IAsyncOperationHandlerInitialized asyncOperationHandler) {
            asyncOperationHandler.Initialize(CreateOperationHandler(-_settings.ZoomAmount));
        }

        void IZoomHandler.ZoomOut(IAsyncOperationHandlerInitialized asyncOperationHandler) {
            asyncOperationHandler.Initialize(CreateOperationHandler(_settings.ZoomAmount));
        }

        protected IAsyncOperation CreateOperationHandler(float zoomAmount) {
            return 
                new InterpolationLinearMathf<UnityEngine.Camera>(
                        targetInstance: _camera,
                        targetProperty: PropInfos.CameraOrthographicSize,
                        startValue: _camera.orthographicSize,
                        finalValue: Mathf.Clamp(_camera.orthographicSize + zoomAmount, _settings.MinZoom, _settings.MaxZoom),
                        byTime: _settings.ZoomSpeed
                    );
        }
    }
}