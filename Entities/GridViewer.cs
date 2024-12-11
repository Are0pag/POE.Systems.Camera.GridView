using UnityEngine;

namespace Scripts.Systems.Camera.GridView
{
    internal class GridViewer : IGidViewer, Zenject.ITickable
    {
        protected readonly CameraStateProvider _cameraStateProvider;
        
        internal GridViewer(IFreeCamera freeCameraComponent, IFocusable focusableComponent, ISwapper swapper, IZoom zoomComponent) {
            FreeCameraComponent = freeCameraComponent;
            FocusableComponent = focusableComponent;
            SwapComponent = swapper;
            ZoomComponent = zoomComponent;
        }

        void Zenject.ITickable.Tick() => _cameraStateProvider.UpdateState();

        public IFreeCamera FreeCameraComponent { get; }
        public IFocusable FocusableComponent { get; }
        public ISwapper SwapComponent { get; }
        public IZoom ZoomComponent { get; }

        
    }
}