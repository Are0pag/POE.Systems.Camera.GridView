using UnityEngine;

namespace Scripts.Systems.Camera.GridView
{
    internal class FocusState : CameraState, IFocusTargetHandler, ICancelOperationHandler
    {
        protected readonly IFocusable _focusable;
        protected readonly IFocusCatcher _focusCatcher;
        
        internal FocusState(IFocusable focusable, IFocusCatcher focusCatcher) {
            _focusable = focusable;
            _focusCatcher = focusCatcher;
        }

        internal override void Update() {
            _focusable.Follow();
        }

        public async void SetFocusTarget(Transform focusTarget) {
            await _focusCatcher.MoveAt(new MoveToSelectedItemArgs(focusTarget));
            _focusable.Target = focusTarget;
        }

        public void CancelOperations() {
            _focusCatcher.Cancel();
        }
    }
}