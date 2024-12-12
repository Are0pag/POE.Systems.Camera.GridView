using System.Reflection;
using Cysharp.Threading.Tasks;
using Scripts.Tools.Interpolation;
using UnityEngine;

namespace Scripts.Systems.Camera.GridView
{
    internal class FocusCatcher : IFocusCatcher
    {
        protected readonly UnityEngine.Camera _camera;
        protected readonly PropertyInfo _propertyInfo;
        protected readonly FocusSettings _settings;
        protected MiddleWareAsync _operationHandler;

        internal FocusCatcher(UnityEngine.Camera camera, Config config) {
            _camera = camera;
            _propertyInfo = typeof(Transform).GetProperty("position");
            _settings = config.FocusSettings;
        }

        public async UniTask MoveAt(MoveToSelectedItemArgs args) {
            
            _operationHandler = new MiddleWareAsync(new InterpolationLinearVector3<Transform>(
                targetInstance: _camera.transform,
                targetProperty: _propertyInfo,
                startValue: _camera.transform.position,
                finalValue: args.Target.transform.position,
                byTime: _settings.CatchSpeed
                ));
            await _operationHandler.RunAsync();
        }
        
        public void Cancel() => _operationHandler?.Cancel();
    }
}