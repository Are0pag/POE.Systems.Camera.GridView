namespace Scripts.Systems.Camera.LocationView.View
{
    internal class SwapButton : CameraModeButton
    {
        internal SwapButton(CameraModeButtonStyle cameraModeButtonStyle) 
            : base(cameraModeButtonStyle) {
        }

        protected override void SetSwitchedState(CameraModeInput cameraModeInput) {
            cameraModeInput.SetCurrentButton(cameraModeInput.FocusButton);
        }
    }
}