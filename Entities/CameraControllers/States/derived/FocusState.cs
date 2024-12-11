using Cysharp.Threading.Tasks;

namespace Scripts.Systems.Camera.GridView
{
    internal class FocusState : CameraState
    {
        protected readonly IFocusable _focusable;
        
        internal FocusState(IFocusable focusable) {
            _focusable = focusable;
        }
        
        internal override async UniTask OnEnter() {
            await UniTask.Yield();
        }

        internal override void Update() {
            throw new System.NotImplementedException();
        }

        internal override void OnSwitch() {
            throw new System.NotImplementedException();
        }
    }
}