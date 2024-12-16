using System;

namespace Scripts.Systems.Camera.GridView.View
{
    internal abstract class CameraModeButton
    {
        protected readonly CameraModeButtonStyle _cameraModeButtonStyle;

        internal Action OnClickAction;

        protected CameraModeButton(CameraModeButtonStyle cameraModeButtonStyle) {
            _cameraModeButtonStyle = cameraModeButtonStyle;
        }

        internal void OnClick(CameraModeInput cameraModeInput) {
            OnClickAction?.Invoke();
            cameraModeInput.ChanchableImage.sprite = _cameraModeButtonStyle.Sprite;
            SetSwitchedState(cameraModeInput);
        }

        protected abstract void SetSwitchedState(CameraModeInput cameraModeInput);
    }
}