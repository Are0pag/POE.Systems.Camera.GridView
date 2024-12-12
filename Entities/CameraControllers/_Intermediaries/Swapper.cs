using Scripts.Services.Input;
using UnityEngine;

namespace Scripts.Systems.Camera.GridView
{
    internal class Swapper : ISwapper, IInputHandler
    {
        protected readonly UnityEngine.Camera _camera;
        protected Vector3 _startPoint;
        protected bool _clickIsFixated;

        public Swapper(UnityEngine.Camera camera) {
            _camera = camera;
        }

        public void HandleSwap() {
            if (_clickIsFixated) {
                var pos = _camera.ScreenToWorldPoint(Input.mousePosition).x - _startPoint.x;
                _camera.transform.position = new Vector3(_camera.transform.position.x - pos, _camera.transform.position.y, _camera.transform.position.z);
            }
        }

        void IInputHandler.OnMouseButtonDown() {
            _startPoint = _camera.ScreenToWorldPoint(Input.mousePosition);
            _clickIsFixated = true;
        }

        void IInputHandler.OnMouseButtonUp() {
            _clickIsFixated = false;
        }
    }
}