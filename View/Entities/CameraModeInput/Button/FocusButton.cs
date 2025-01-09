namespace Scripts.Systems.Camera.LocationView.View
{
    internal class FocusButton : CameraModeButton
    {
        internal FocusButton(CameraModeButtonStyle cameraModeButtonStyle) 
            : base(cameraModeButtonStyle) {
        }

        protected override void SetSwitchedState(CameraModeInput cameraModeInput) {
            cameraModeInput.SetCurrentButton(cameraModeInput.SwapButton);
        }
    }
}