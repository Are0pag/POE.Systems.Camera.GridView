using Scripts.Services.EventBus;
using Scripts.Tools;
using UnityEngine;
using Zenject;

namespace Scripts.Systems.Camera.GridView
{
    internal class Swapper : ISwapper, IInputHandler, IInitializable, ILateDisposable, ISwapContextContainer
    {
        protected readonly UnityEngine.Camera _camera;
        protected readonly SwapSettings _settings;
        protected Vector3 _startPoint;
        protected bool _clickIsFixated;

        public SwapContextSettings SwapContextSettings { get; set; }
        
        public Swapper(UnityEngine.Camera camera, SwapSettings swapSettings) {
            _camera = camera;
            _settings = swapSettings;
        }

        public void HandleSwap() {
            if (_clickIsFixated) {
                var pos = _camera.ScreenToWorldPoint(Input.mousePosition) - _startPoint;
                _camera.transform.position = Clamp(GetDesiredPosition(pos));
            }
        }

        private Vector3 GetDesiredPosition(UnityEngine.Vector3 pos) {
            return new Vector3(
                _camera.transform.position.x - pos.x * _settings.SensitivityX, 
                _camera.transform.position.y - pos.y * _settings.SensitivityY, 
                _camera.transform.position.z);
        }

        private Vector3 Clamp(Vector3 desiredPosition) {
            if (SwapContextSettings is null) {
                EventBus<IExternalGridViewEventHandler>.RaiseEvent<ISwapContextSettingsRequestHandler>
                    (action: h => h.GetContextSettings(container: this));
                return desiredPosition;
            }
            
            return desiredPosition.Clamp(
                min: new Vector3(x: SwapContextSettings.LeftMapSideX, y: SwapContextSettings.LowerMapSideY, z: _camera.transform.position.z),
                max: new Vector3(x: SwapContextSettings.RightMapSideX, y: SwapContextSettings.UpperMapSideY, z: _camera.transform.position.z));
        }

        private float GetPositionX(Vector3 pos) {
            var nexPos = _camera.transform.position.x - pos.x * _settings.SensitivityX;
            
            if (SwapContextSettings is null) {
                EventBus<IExternalGridViewEventHandler>.RaiseEvent<ISwapContextSettingsRequestHandler>
                    (h => h.GetContextSettings(this));
                return nexPos;
            }
            
            return Mathf.Clamp(nexPos, 
                SwapContextSettings.LeftMapSideX - _settings.VisibleDistanceOutOfTheMapSides, 
                SwapContextSettings.RightMapSideX + _settings.VisibleDistanceOutOfTheMapSides);
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