namespace Scripts.Systems.Camera.GridView.View
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