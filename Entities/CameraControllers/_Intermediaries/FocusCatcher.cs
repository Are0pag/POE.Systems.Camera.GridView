using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Cysharp.Threading.Tasks;
using Scripts.Tools.AsyncOperationsHandle;
using Scripts.Tools.Interpolation;
using UnityEngine;

namespace Scripts.Systems.Camera.GridView
{
    internal class FocusCatcher : IFocusCatcher
    {
        protected readonly UnityEngine.Camera _camera;
        protected readonly PropertyInfo _propertyInfo;
        protected readonly FocusSettings _settings;
        
        [AllowNull] 
        protected AsyncOperationHandler _operationHandler;

        internal FocusCatcher(UnityEngine.Camera camera, Config config) {
            _camera = camera;
            _propertyInfo = typeof(Transform).GetProperty("position");
            _settings = config.FocusSettings;
        }

        public async UniTask MoveAt(MoveToSelectedItemArgs args) {
            
            _operationHandler = new AsyncOperationHandler(new InterpolationLinearVector3<Transform>(
                targetInstance: _camera.transform,
                targetProperty: _propertyInfo,
                startValue: new Vector3(_camera.transform.position.x, _camera.transform.position.y, Config.CAMERA_POS_Z),
                finalValue: new Vector3(args.Target.x, args.Target.y, Config.CAMERA_POS_Z),
                byTime: _settings.CatchSpeed
                ));
            await _operationHandler.RunAsync();
        }
        
        public void Cancel() => _operationHandler?.Cancel();
    }
}