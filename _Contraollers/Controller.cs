using System.Diagnostics.CodeAnalysis;

namespace Scripts.Systems.Camera.GridView
{
    internal class Controller : ICameraModeHandler
    {
        protected readonly GridViewer _gridView;

        public Controller(GridViewer gridView) {
            _gridView = gridView;
        }

        public void SwitchCameraMode([DisallowNull] CameraState newCameraState) {
            _gridView.SwitchState(newCameraState);
        }
    }
}