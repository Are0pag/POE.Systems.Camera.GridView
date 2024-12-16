using System.Reflection;
using Cysharp.Threading.Tasks;
using Scripts.Tools.Interpolation;

namespace Scripts.Systems.Camera.GridView
{
    internal class Zoom : IZoom, ICancelable
    {
        protected readonly UnityEngine.Camera _camera;
        protected readonly PropertyInfo _zoomProperty;
        protected readonly ZoomSettings _settings;
        protected AsyncOperationHandler _middleWare;

        public Zoom(UnityEngine.Camera camera, Config config) {
            _camera = camera;
            _zoomProperty = typeof(UnityEngine.Camera).GetProperty("orthographicSize");
            _settings = config.ZoomSettings;
        }
        
        public async UniTask ZoomIn() {
            await CreateOperationHandler(_settings.ZoomAmount).RunAsync();
        }

        public async UniTask ZoomOut() {
            await CreateOperationHandler(-_settings.ZoomAmount).RunAsync();
        }

        public void Cancel() => _middleWare?.Cancel();

        private AsyncOperationHandler CreateOperationHandler(float zoomAmount) {
            _middleWare = new AsyncOperationHandler(new InterpolationLinearMathf<UnityEngine.Camera>(
                targetInstance: _camera,
                targetProperty: _zoomProperty,
                startValue: _camera.orthographicSize,
                finalValue: _camera.orthographicSize + zoomAmount,
                byTime: _settings.ZoomSpeed
            ));
            return _middleWare;
        }
        
    }

    
}