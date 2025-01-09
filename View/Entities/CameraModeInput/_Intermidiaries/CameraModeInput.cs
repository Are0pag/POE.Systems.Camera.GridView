using System;
using Scripts.Tools.Attributes;
using Scripts.Tools.View;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Systems.Camera.LocationView.View
{
    internal class CameraModeInput : MonoBehaviour
    {
        [SerializeField] [GetComponent] protected LinkedButton _cameraModeButton;
        internal protected LinkedButton CameraModeButton {
            get => _cameraModeButton;
            protected set => _cameraModeButton = value;
        }
        [SerializeField] protected Image _chanchableImage;
        internal protected Image ChanchableImage {
            get => _chanchableImage;
            protected set => _chanchableImage = value;
        }


        protected CameraModeButton _currentModeButton;
        internal readonly FocusButton FocusButton;
        internal readonly SwapButton SwapButton;
        
        /* ViewSetting централизованы, то есть все настройки устанавливаются из одного места,
            следовательно получение этих данных попадает в зону ответственности DI */
        
        internal CameraModeInput(FocusButton focusButton, SwapButton swapButton) {
            FocusButton = focusButton;
            SwapButton = swapButton;
        }
        
        internal void InitTopDown(Action focusButtonAction, Action swapButtonAction) {
            FocusButton.OnClickAction = focusButtonAction;
            SwapButton.OnClickAction = swapButtonAction;
            
            _cameraModeButton.onClick.AddListener(() => {
               _currentModeButton.OnClick(this);
            });
        }

        internal void SetCurrentButton(CameraModeButton cameraModeButton) {
            _currentModeButton = cameraModeButton;
        }
    }
}