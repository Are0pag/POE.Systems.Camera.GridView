using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace Scripts.Systems.Camera.GridView
{
    public class FreeViewState : CameraState, ICancelOperationHandler
    {
        protected private readonly IFreeCamera _freeCamera;

        internal FreeViewState(IFreeCamera freeCamera) {
            _freeCamera = freeCamera;
        }

        internal override void Update() { }

        internal async UniTask ViewLocation(ShowMapArgs args) {
            await _freeCamera.ShowMapAsyncRecursive(args);
        }

        public void CancelOperations() => _freeCamera.Cancel();
    }
}