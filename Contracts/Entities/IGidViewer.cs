using Cysharp.Threading.Tasks;
using UnityEngine;

// Считает ли Zenject в методе BindInterfaces<> абстрактный класс как эквивалентную сущность?

namespace Scripts.Systems.Camera.GridView
{
    internal interface IGidViewer : Zenject.ITickable
    {
        IFreeCamera FreeCameraComponent { get; }
        
        IFocusable FocusableComponent { get; }
        
        ISwapper SwapComponent { get; }
        
        IZoom ZoomComponent { get; }
    }

    internal interface IFreeCamera
    {
        // но как тогда быть с реализацией RaiseEvent? Метод же асинхронный
        UniTask ShowMap(ShowMapArgs args);
    }

    internal interface IZoom
    {
        void ZoomIn();
        
        void ZoomOut();
    }

    internal interface IFocusable
    {
        Vector3 FocusPoint { get; }

        UniTask MoveToSelectedItem(MoveToSelectedItemArgs args);

        UniTask Return();
    }

    internal interface ISwapper
    {
        bool IsSwapAllows { get; set; }
        
        void HandleSwap();    
    }

    internal class GidViewer : IGidViewer
    {
        internal GidViewer(IFreeCamera freeCameraComponent, IFocusable focusableComponent, ISwapper swapper, IZoom zoomComponent) {
            FreeCameraComponent = freeCameraComponent;
            FocusableComponent = focusableComponent;
            SwapComponent = swapper;
            ZoomComponent = zoomComponent;
        }
        
        void  Zenject.ITickable.Tick() => SwapComponent.HandleSwap();

        public IFreeCamera FreeCameraComponent { get; }
        public IFocusable FocusableComponent { get; }
        public ISwapper SwapComponent { get; }
        public IZoom ZoomComponent { get; }
    }

    internal class SwapComponent : ISwapper
    {
        protected readonly UnityEngine.Camera _camera;
        protected Vector3 _startPoint;

        public bool IsSwapAllows { get; set; }

        public SwapComponent(UnityEngine.Camera camera, Config config) {
            _camera = camera;
            IsSwapAllows = config.IsSwapAllowsOnEnable;
        }

        public void HandleSwap() {
            if (!IsSwapAllows) 
                return;

            if (Input.GetMouseButtonDown(0)) {
                _startPoint = _camera.ScreenToWorldPoint(Input.mousePosition);
            }
            else if (Input.GetMouseButton(0)) {
                var pos = _camera.ScreenToWorldPoint(Input.mousePosition).x - _startPoint.x;
                _camera.transform.position = new Vector3(_camera.transform.position.x - pos, _camera.transform.position.y, _camera.transform.position.z);
            }
        }
    }

    // Неплоxо было бы иметь сслку на EventBus и уже там определить эти аргументы

    internal abstract class ShowMapArgs : Args
    {
        
    }

    internal abstract class MoveToSelectedItemArgs : Args
    {
        
    }

    /*
    Action actEvent;
    UnityAction unityEvent; // especially used in uGUI

        // Bad: async void
    actEvent += async () => { };
    unityEvent += async () => { };

        // Ok: create Action delegate by lambda
    actEvent += UniTask.Action(async () => { await UniTask.Yield(); });
    unityEvent += UniTask.UnityAction(async () => { await UniTask.Yield(); });
    */
}