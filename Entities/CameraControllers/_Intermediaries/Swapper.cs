using Scripts.Services.EventBus;
using UnityEngine;
using Zenject;

namespace Scripts.Systems.Camera.GridView
{
    internal class Swapper : ISwapper, IInputHandler, IInitializable, ILateDisposable
    {
        protected readonly UnityEngine.Camera _camera;
        protected readonly SwapSettings _settings;
        protected Vector3 _startPoint;
        protected bool _clickIsFixated;

        public Swapper(UnityEngine.Camera camera, SwapSettings swapSettings) {
            _camera = camera;
            _settings = swapSettings;
        }

        public void HandleSwap() {
            if (_clickIsFixated) {
                var pos = _camera.ScreenToWorldPoint(Input.mousePosition) - _startPoint;
                _camera.transform.position = new Vector3(
                    _camera.transform.position.x - pos.x * _settings.SensitivityX, 
                    _camera.transform.position.y - pos.y * _settings.SensitivityY, 
                    _camera.transform.position.z);
            }
        }

        void IInputHandler.OnMouseButtonDown() {
            _startPoint = _camera.ScreenToWorldPoint(Input.mousePosition);
            _clickIsFixated = true;
        }

        void IInputHandler.OnMouseButtonUp() {
            _clickIsFixated = false;
        }

        public void Initialize() {
            EventBus<IExternalGridViewEventHandler>.Subscribe(this);
        }

        public void LateDispose() {
            EventBus<IExternalGridViewEventHandler>.Unsubscribe(this);
        }
    }
}